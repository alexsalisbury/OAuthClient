namespace Home.OAuthClients.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Home.OAuthClients.Models;

    public abstract partial class RestApiClient
    {
        protected static HttpClient Client;

        internal static void SetupClient(HttpClient client = null, bool force = false)
        {
            Client = force ? new HttpClient() : client ?? new HttpClient();
        }

        public static async Task<HTTPResult<T>> GetAsync<T>(string requestUrl)
        {
            var response = await Client.GetAsync(requestUrl, HttpCompletionOption.ResponseContentRead);
            var resultContent = await response.Content.ReadAsStringAsync();

            return new HTTPResult<T>(response.StatusCode, resultContent, response.IsSuccessStatusCode);
        }

        public static async Task<HTTPResult<T>> PostAsync<T>(string requestUrl, IEnumerable<KeyValuePair<string, string>> body)
        {
            using (var content = new FormUrlEncodedContent(body))
            {
                return await PostAsync<T>(requestUrl, content);
            }
        }

        public static async Task<HTTPResult<T>> PostAsync<T>(string requestUrl, string body, string contentType = null)
        {
            var content = new StringContent(body);
            if (!string.IsNullOrEmpty(contentType))
            {
                content.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
            }

            return await PostAsync<T>(requestUrl, content);
        }

        public static async Task<HTTPResult<T>> PostAsync<T>(string requestUrl, HttpContent content)
        {
            var response = await Client.PostAsync(requestUrl, content);
            var resultContent = await response.Content.ReadAsStringAsync();

            return new HTTPResult<T>(response.StatusCode, resultContent, response.IsSuccessStatusCode);
        }

        public static async Task<HTTPResult<T>> PutAsync<T>(string requestUrl, IEnumerable<KeyValuePair<string, string>> body)
        {
            using (var content = new FormUrlEncodedContent(body))
            {
                return await PutAsync<T>(requestUrl, content);
            }
        }

        public static async Task<HTTPResult<T>> PutAsync<T>(string requestUrl, string body, string contentType = null)
        {
            var content = new StringContent(body);
            if (!string.IsNullOrEmpty(contentType))
            {
                content.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
            }

            return await PutAsync<T>(requestUrl, content);
        }

        public static async Task<HTTPResult<T>> PutAsync<T>(string requestUrl, HttpContent content)
        {
            var response = await Client.PutAsync(requestUrl, content);
            var resultContent = await response.Content.ReadAsStringAsync();

            return new HTTPResult<T>(response.StatusCode, resultContent, response.IsSuccessStatusCode);
        }

        public static async Task<HTTPResult> DeleteAsync(string requestUrl)
        {
            var response = await Client.DeleteAsync(requestUrl);
            string resultContent = null;

            if (response.Content != null)
                resultContent = await response.Content?.ReadAsStringAsync();

            ValidateResponseCode(response.StatusCode, resultContent);

            return new HTTPResult(response.StatusCode, resultContent, response.IsSuccessStatusCode);
        }

        /// <summary>
        /// Validates a <see cref="HttpStatusCode"/> and throws errors based on the code.
        /// </summary>
        /// <param name="statusCode">The status code to validate.</param>
        /// <param name="response">The response of the http request.</param>
        public static void ValidateResponseCode(HttpStatusCode statusCode, string response)
        {
            switch (statusCode)
            {
            //    case HttpStatusCode.BadRequest:
            //        throw new BadRequestException(response);
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException(response);
            //    case HttpStatusCode.Forbidden:
            //        throw new ForbiddenException(response);
            //    case HttpStatusCode.NotFound:
            //        throw new NotFoundException(response);
            //    case HttpStatusCode.InternalServerError:
            //        throw new InternalServerErrorException(response);
            //    case HttpStatusCode.BadGateway:
            //        throw new BadGatewayException(response);
            //    case HttpStatusCode.ServiceUnavailable:
            //        throw new ServiceUnavailableException(response);
            }

            //// This status code is not in the HttpStatusCode Enum
            //if ((int)statusCode == 429)
            //{
            //    throw new TooManyRequestsException(response);
            //}
        }
    }
}