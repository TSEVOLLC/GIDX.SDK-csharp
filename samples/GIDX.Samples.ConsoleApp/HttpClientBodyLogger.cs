using Microsoft.Extensions.Http.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GIDX.Samples.ConsoleApp
{
    internal class HttpClientBodyLogger : IHttpClientAsyncLogger
    {
        private readonly ILogger<HttpClientBodyLogger> logger;

        public HttpClientBodyLogger(ILogger<HttpClientBodyLogger> logger)
        {
            this.logger = logger;
        }

        public void LogRequestFailed(object context, HttpRequestMessage request, HttpResponseMessage response, Exception exception, TimeSpan elapsed)
        {
            
        }

        public ValueTask LogRequestFailedAsync(object context, HttpRequestMessage request, HttpResponseMessage response, Exception exception, TimeSpan elapsed, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }

        public object LogRequestStart(HttpRequestMessage request)
        {
            return null;
        }

        public async ValueTask<object> LogRequestStartAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
        {
            if (request.Content != null)
            {
                var body = await request.Content.ReadAsStringAsync();
                logger.LogTrace(JsonPrettify(body));
            }

            return null;
        }

        public void LogRequestStop(object context, HttpRequestMessage request, HttpResponseMessage response, TimeSpan elapsed)
        {

        }

        public async ValueTask LogRequestStopAsync(object context, HttpRequestMessage request, HttpResponseMessage response, TimeSpan elapsed, CancellationToken cancellationToken = default)
        {
            var body = await response.Content.ReadAsStringAsync();
            logger.LogTrace(JsonPrettify(body));
        }

        private string JsonPrettify(string body)
        {
            try
            {
                using var jsonDoc = JsonDocument.Parse(body);
                body = JsonSerializer.Serialize(jsonDoc, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
            catch (Exception ex) { }

            return body;
        }
    }
}
