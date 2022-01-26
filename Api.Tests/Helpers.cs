using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Api.Tests
{
    internal static class Helpers
    {
        internal static ByteArrayContent BuildByteContent<T>(this T entity)
        {
            var myContent = JsonConvert.SerializeObject(entity);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }

        internal static async Task<T> DeserializeContentAsync<T>(this HttpResponseMessage? httpResponseMessage)
        {
            if(httpResponseMessage is null) return default!;

            var responseContent = await httpResponseMessage.Content
                .ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}