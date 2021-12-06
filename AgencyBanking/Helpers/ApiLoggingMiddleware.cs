using AgencyBanking.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyBanking.Helpers
{
    public class ApiLoggingMiddleware
    {

        private readonly RequestDelegate _next;
        private ApiLogService _apiLogService;

        public ApiLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ApiLogService apiLogService)
        {
            try
            {
                _apiLogService = apiLogService;

                var request = httpContext.Request;
                if (request.Path.StartsWithSegments(new PathString("/api")))
                {
                    var stopWatch = Stopwatch.StartNew();
                    var requestTime = DateTime.UtcNow;
                    var requestBodyContent = await ReadRequestBody(request);
                    var originalBodyStream = httpContext.Response.Body;
                    using (var responseBody = new MemoryStream())
                    {
                        var response = httpContext.Response;
                        response.Body = responseBody;
                        await _next(httpContext);
                        stopWatch.Stop();

                        string responseBodyContent = null;
                        responseBodyContent = await ReadResponseBody(response);
                        await responseBody.CopyToAsync(originalBodyStream);

                        await SafeLog(requestTime,
                            stopWatch.ElapsedMilliseconds,
                            response.StatusCode,
                            request.Method,
                            request.Path,
                            request.QueryString.ToString(),
                            requestBodyContent,
                            responseBodyContent);
                    }
                }
                else
            {
                await _next(httpContext);
            }
        }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await _next(httpContext);
            }
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }

        private async Task<string> ReadResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var bodyAsText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }

        private async Task SafeLog(DateTime requestTime, long responseMillis, int statusCode, string method, string path, string queryString, string requestBody, string responseBody)
        {
            if (path.ToLower().StartsWith("/api/login"))
            {
                requestBody = "(Request logging disabled for /api/login)";
                responseBody = "(Response logging disabled for /api/login)";
            }

            //if (requestBody.Length > 5000)
            //{
            //    requestBody = $"(Truncated to 5000 chars) {requestBody.Substring(0, 5000)}";
            //}

            //if (responseBody.Length > 15000)
            //{
            //    responseBody = $"(Truncated to 15000 chars) {responseBody.Substring(0, 15000)}";
            //}

            //if (queryString.Length > 500)
            //{
            //    queryString = $"(Truncated to 500 chars) {queryString.Substring(0, 500)}";
            //}

            await _apiLogService.Log(new Apilogitem
            {
                Requesttime = requestTime,
                Responsemillis = responseMillis,
                Statuscode = statusCode,
                Method = method,
                Path = path,
                Querystring = queryString,
                Requestbody = requestBody,
                Responsebody = responseBody
            });
        }
    }
}
