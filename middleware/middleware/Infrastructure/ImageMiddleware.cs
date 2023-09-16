using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
//using static System.Net.Mime.MediaTypeNames;

namespace middleware.Infrastructure
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ImageMiddleware
    {
        private readonly RequestDelegate _next;

        public ImageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string url = httpContext.Request.Path;
            if (url.ToLower().Contains(".jpg"))
            {
                var name = httpContext.Request.Path.ToString();
                if (File.Exists("img/" + name))
                {
                    Image img = Image.FromFile("./img/" + name);


                    //WATERMARK
                    string text = "watermark";
                    int width = img.Width;
                    int height = img.Height;
                    int font_size = (width > height ? height : width) / 9;

                    Point text_starting_point = new Point(height / 4, (width / 4));

                    Font text_font = new Font("Arial", font_size, FontStyle.Bold, GraphicsUnit.Pixel);

                    Color color = Color.FromArgb(70, 40, 4, 40);
                    SolidBrush brush = new SolidBrush(color);

                    Graphics graphics = Graphics.FromImage(img);
                    graphics.DrawString(text, text_font, brush, text_starting_point);
                    graphics.Dispose();
                    //WATERMARK


                    MemoryStream stream = new MemoryStream();
                    img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    httpContext.Response.ContentType = "image/jpeg";
                    return httpContext.Response.Body.WriteAsync(stream.ToArray(), 0,
                    (int)stream.Length);
                }
                else
                {
                    return httpContext.Response.WriteAsync("Nie udalo sie znalezc tego zdjecia.");
                }
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ImageMiddlewareExtensions
    {
        public static IApplicationBuilder UseImageMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ImageMiddleware>();
        }
    }
}
