using AvaloniaChat.Common.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaChat.Model
{
    public class OpenAIHttpClientHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            UriBuilder uriBuilder;
            string url = OpenAIOption.Endpoint;
            string platform = OpenAIOption.Platform;
            Uri uri = new Uri(url);
            string host = uri.Host;
            switch (request.RequestUri?.LocalPath)
            {
                case "/v1/chat/completions":
                    switch(platform)
                    {
                        case "ZhiPu":
                            uriBuilder = new UriBuilder(request.RequestUri)
                            {
                                // 这里是你要修改的 URL
                                Scheme = "https",
                                Host = host,
                                Path = "api/paas/v4/chat/completions",
                            };
                            request.RequestUri = uriBuilder.Uri;
                            break;
                        default:
                            uriBuilder = new UriBuilder(request.RequestUri)
                            {
                                // 这里是你要修改的 URL
                                Scheme = "https",
                                Host = host,
                                Path = "v1/chat/completions",
                            };
                            request.RequestUri = uriBuilder.Uri;
                            break;
                    }
                    break;
            }
        
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
          
            return response;
        }
    }
}
