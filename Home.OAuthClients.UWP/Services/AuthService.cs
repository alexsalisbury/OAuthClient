namespace Home.OAuthClients.UWP
{
    using System;
    using System.Threading.Tasks;
    using Windows.Security.Authentication.Web;
    using Newtonsoft.Json;
    using Home.OAuthClients.Models;

    public interface IAuthService
    {
        Task<T> GetTokenAsync<T>(Uri startUri, WebAuthenticationOptions options) where T : Token;
        Task<string> GetTokenAsync(Uri startUri, WebAuthenticationOptions options);
    }

    public class AuthService: IAuthService
    {
        public virtual async Task<T> GetTokenAsync<T>(Uri startUri, WebAuthenticationOptions options = WebAuthenticationOptions.None) where T : Token
        {
            string token = await GetTokenAsync(startUri);

            if (string.IsNullOrEmpty(token))
            { 
                return null;
            }

            return JsonConvert.DeserializeObject<T>(token);
        }

        public virtual async Task<string> GetTokenAsync(Uri startUri, WebAuthenticationOptions options = WebAuthenticationOptions.None)
        {
            var result = await WebAuthenticationBroker.AuthenticateAsync(options, startUri);
            if (result.ResponseStatus == WebAuthenticationStatus.Success)
            {
                return result.ResponseData.ToString();
            }

            return null;
        }
    }
}