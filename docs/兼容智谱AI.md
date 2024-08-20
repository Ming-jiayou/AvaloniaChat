## 兼容智谱AI

Semantie Kernel中对话请求默认是发送到OpenAI去的：

![image-20240820135810583](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240820135810583.png)

其他与OpenAI对话请求接口兼任的模型平台，一般只需要修改host即可，如下所示：

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

但是智普AI的对话接口地址如下：

![image-20240820140509016](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240820140509016.png)

在python中这样就可以用，但SemanticKernel中好像还没有base_url的设置。

有两种方式可以实现。

一种是想和之前其他模型用相同的方式，把智普平台作为一种特殊的方式处理。

在appsettings.json中添加一个Platform字段，请求接口完全兼容OpenAI的可以不写：

![image-20240820141319013](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240820141319013.png)

创建Kernel是这样的：

```csharp
 var builder = Kernel.CreateBuilder()
 .AddOpenAIChatCompletion(
    modelId: OpenAIOption.ChatModel,
    apiKey: OpenAIOption.Key,
    httpClient: new HttpClient(handler));
_kernel = builder.Build();
```

然后再OpenAIHttpClientHandler为智普平台做一下不同的处理：

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

尝试是否成功：

![image-20240820141544371](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240820141544371.png)

另一种方式更加简单，只需要在appsettings.json中这样写：

![image-20240820141816259](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240820141816259.png)

使用这种方式创建Kernel即可：

![image-20240820141925142](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240820141925142.png)

尝试是否成功：

![image-20240820142138323](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240820142138323.png)

在AvaloniaChat中为了和其他平台保持统一的使用方式，我选择第一种方式。

