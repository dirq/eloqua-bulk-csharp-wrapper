using System;
using System.Text;

namespace Eloqua.Api.Bulk.Authentication
{
    internal static class BasicAuthentication
    {
        internal static string BuildAuthHeader(string username, string password)
        {
            string credentials = $"{username}:{password}";
            byte[] bytes = Encoding.ASCII.GetBytes(credentials);
            string base64 = Convert.ToBase64String(bytes);

            return $"basic {base64}";
        }
    }
}
