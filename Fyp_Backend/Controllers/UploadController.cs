using Fyp_Backend.Extensions;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Fyp_Backend
{
    [RoutePrefix("api")]
    public class UploadController : ApiController
    {
        [Route("upload")]
        [HttpPost]
        public async Task<HttpResponseMessage> UploadFile(HttpRequestMessage request)
        {
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var data = await Request.Content.ParseMultipartAsync();

            if (data.Files.ContainsKey("file"))
            {
                var file = data.Files["file"].File;
                var fileName = data.Files["file"].Filename;

                Console.WriteLine("File: " + file);
                Console.WriteLine("File: " + fileName);
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Thank you for uploading the file...")
            };
        }
    }
}
