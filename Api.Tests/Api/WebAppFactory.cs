using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Api.Tests.Api
{
    internal class WebAppFactory : WebApplicationFactory<Program>
    {
        public readonly string _environment;
        public WebAppFactory(string environment = "Development")
        {
            _environment = environment;
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment(_environment);

            return base.CreateHost(builder);
        }

        public static ByteArrayContent BuildContent<T>(T entity)
        {
            var myContent = JsonConvert.SerializeObject(entity);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }
    }
}
