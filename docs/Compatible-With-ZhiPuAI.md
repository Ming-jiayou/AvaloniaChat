# Compatible with ZhiPuAI

The dialogue request in Semantic Kernel is sent to OpenAI by default:

![image-20240820135810583](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240820135810583.png)

Other model platforms that are compatible with the OpenAI dialogue request interface generally only require the modification of the host, as shown below:

```csharp
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
```

However, the dialogue interface address for ZhiPuAI is as follows:

![image-20240820140509016](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240820140509016.png)

In Python, this can be done, but it seems that SemanticKernel does not have a setting for `base_url` yet.

There are two ways to achieve this.

One way is to treat the ZhiPu platform as a special case, similar to how other models are handled. Add a `Platform` field in `appsettings.json`, and you don't need to write anything if the request interface is fully compatible with OpenAI:

![image-20240820141319013](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240820141319013.png)

Creating a kernel is like this:

```csharp
 var builder = Kernel.CreateBuilder()
 .AddOpenAIChatCompletion(
    modelId: OpenAIOption.ChatModel,
    apiKey: OpenAIOption.Key,
    httpClient: new HttpClient(handler));
_kernel = builder.Build();
```

Then perform different processing for ZhiPuAI in the OpenAIHttpClientHandler:

```csharp
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
```

Attempt to verify:

![image-20240820141544371](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240820141544371.png)

Another way is even simpler, just write in appsettings.json like this:

![image-20240820141816259](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240820141816259.png)

Here's how you can create a kernel: 

![image-20240820141925142](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240820141925142.png)

Attempt to verify:

![image-20240820142138323](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240820142138323.png)

In AvaloniaChat, I chose the first method to maintain a consistent usage pattern with other platforms.

