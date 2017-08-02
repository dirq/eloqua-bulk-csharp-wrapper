using System.IO;
using System.Net;
using System.Threading.Tasks;
using Eloqua.Api.Bulk.Authentication;

namespace Eloqua.Api.Bulk.Clients.Base
{
    public abstract class ImportCsvClient : ImportClient
    {
        protected ImportCsvClient(BaseClient client) : base(client)
        {
        }

        public async Task ImportDataFromCsvAsync(string importUri, string fileToUpload, string username, string password)
        {
            using (var fileStream = new FileStream(fileToUpload, FileMode.Open))
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Client.BaseUrl}{importUri}/data");
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentLength = fileStream.Length;
                httpWebRequest.ContentType = "text/csv";
                httpWebRequest.AllowWriteStreamBuffering = true;
                httpWebRequest.Headers.Add("Authorization", BasicAuthentication.BuildAuthHeader(username, password));

                using (Stream reqStream = await httpWebRequest.GetRequestStreamAsync())
                {
                    var inData = new byte[fileStream.Length];

                    reqStream.Write(inData, 0, (int)fileStream.Length);

                    fileStream.Close();
                    await httpWebRequest.GetResponseAsync();
                }
            }
        }
    }
}