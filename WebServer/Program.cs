using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace WebServer
{
    public class Program
    {
        internal static Action<string> Request_arrived;
        public static void Run(Action<string> request_arrived, int portnumber)
        {
            Request_arrived = request_arrived;
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:"+portnumber);
                })
                .Build()
                .Run();
        }
        public static void Main()
        {
            throw new NotImplementedException();
        }
    }
    public class Startup
    {
        public Startup() { }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", c => c.Response.WriteAsync("Hello world!"));
                endpoints.MapPost("/step", (HttpContext httpContext) =>
                {
                    string bodyStr = "";
                    using (StreamReader reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                    {
                        bodyStr = reader.ReadToEnd();
                    }
                    Program.Request_arrived(bodyStr);
                    httpContext.Response.StatusCode = 200;
                    return Task.CompletedTask;
                });
            });
        }
    }
}