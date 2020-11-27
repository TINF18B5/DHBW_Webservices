using System;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CustomerDemo.Model;
using CustomerDemo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
//using Microsoft.AspNetCore.
using Microsoft.Net.Http.Headers;

namespace CustomerDemo.Controllers
{
    public class CustomerImageFormatter : OutputFormatter
    {
        public IWebHostEnvironment HostingEnvironment { get; }
        public CustomerImageFormatter(IWebHostEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
            SupportedMediaTypes.Add("image/png");
            SupportedMediaTypes.Add("image/jpeg");
        }

        protected override bool CanWriteType(Type type)
        {
            if (typeof(Customer).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var responseStream = context.HttpContext.Response.Body;
            var c = context.Object as Customer;

            if (!string.IsNullOrEmpty(c?.ImageFile))
            {
                var rootPath = Path.Combine(HostingEnvironment.WebRootPath, "Images");
                var imagePath = Path.Combine(rootPath, c.ImageFile);
                var buf = File.ReadAllBytes(imagePath);
                await responseStream.WriteAsync(buf, 0, buf.Length);
            }

            // return Task.FromResult(responseStream);

        }

    }
}