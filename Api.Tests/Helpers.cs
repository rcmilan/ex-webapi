using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Api.Tests
{
    internal class Helpers
    {
        public static ByteArrayContent BuildContent<T>(T entity)
        {
            var myContent = JsonConvert.SerializeObject(entity);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }
    }
}
