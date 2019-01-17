namespace Home.OAuthClients.Extensions
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Encodes a string to Base64.
        /// </summary>
        /// <param name="plainText">The string to encode.</param>
        /// <returns>The base 64 encoded string.</returns>
        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}