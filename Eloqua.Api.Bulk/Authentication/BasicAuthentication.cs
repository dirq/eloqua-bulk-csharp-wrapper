using System;
using System.Text;

namespace Eloqua.Api.Bulk.Authentication
{
    internal static class BasicAuthentication
    {
        internal static string BuildAuthHeader(string username, string password)
        {
            string credentials = string.Format("{0}:{1}", username, password);
            byte[] bytes = Encoding.ASCII.GetBytes(credentials);
            string base64 = Convert.ToBase64String(bytes);

            return string.Format("basic {0}", base64);
        }
    }
}
