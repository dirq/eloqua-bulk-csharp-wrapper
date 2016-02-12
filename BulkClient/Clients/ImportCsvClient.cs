using System.IO;
using System.Net;
using Eloqua.Api.Bulk.Authentication;

namespace Eloqua.Api.Bulk.Clients
{
    public abstract class ImportCsvClient : ImportClient
    {
        protected ImportCsvClient(BaseClient client) : base(client)
        {
        }

        public void ImportDataFromCsv(string importUri, string fileToUpload, string username, string password)
        {
            using (FileStream fileStream = new FileStream(fileToUpload, FileMode.Open))
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Client.BaseUrl}{importUri}/data");
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentLength = fileStream.Length;
                httpWebRequest.ContentType = "text/csv";
                httpWebRequest.AllowWriteStreamBuffering = true;
                httpWebRequest.Headers.Add("Authorization", BasicAuthentication.BuildAuthHeader(username, password));

                using (Stream reqStream = httpWebRequest.GetRequestStream())
                {
                    byte[] inData = new byte[fileStream.Length];

                    reqStream.Write(inData, 0, (int)fileStream.Length);

                    fileStream.Close();
                    httpWebRequest.GetResponse();
                }
            }
        }
    }
}
