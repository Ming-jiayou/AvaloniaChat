[简体中文](./README.zh.md) | English

# AvaloniaChat

## A Simple Application Based on a Large Language Model for Translation✨

## Introduction

**A simple application of using a large language model for translation.**

**My main use case**

While reading English literature, I prefer to compare translated versions. Although some software already has built-in translation functions, I still favor translations from large language models. However, I have to copy and paste the English text each time and manually add prompts, and the translated text doesn't align well for comparison.

Therefore, I have developed this software based on Avalonia and Semantic Kernel to address my own needs, and I'm open-sourcing it so that everyone can use it for free. I hope it will be of help to those with similar needs.

![](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/AvaloniaChat02.png)

## Quick Start

Note the 'Releases' section here:

![image-20240816093724343](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816093724343.png)

Clicking on the 'AvaloniaChat-v0.0.1-win-x64.zip' will result in the download:

![image-20240816093952249](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816093952249.png)

After decompressing, open the folder and it looks like this:

![image-20240816094206770](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816094206770.png)

Now, all you need to do is make a simple edit to the appsettings.json file, which is used to configure the large language model you're using.

Taking SiliconCloud as an example, it is most recommended to use SiliconCloud. Both Qwen/Qwen2-7B-Instruct are reportedly free and have fast inference speeds.

After registering on SiliconCloud, create an Api Key and copy this Api Key:

![image-20240816094640258](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816094640258.png)

Open the appsettings.json file, if using SiliconCloud, you only need to fill in the API Key:

![image-20240816094800525](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816094800525.png)

Now that the configuration is complete, you can use it by clicking the exe file:

![image-20240816094827621](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816094827621.png)

Question for AI:

![](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/AvaloniaChat-v0.0.1.gif)

![image-20240816095611412](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816095611412.png)

Translation from English to Chinese:

![](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/AvaloniaChat-v0.0.1-2.gif)

![image-20240816100534403](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816100534403.png)

Translation from Chinese to English:

![](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/AvaloniaChat-v0.0.1-3.gif)

![image-20240816100742362](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816100742362.png)

#### Configure other large language models

**Xunfei Spark**

Using Spark Max as an example,configure the appsettings.json file like this:

```json
{
  "OpenAI": {
    "Key": "your key",
    "Endpoint": "https://spark-api-open.xf-yun.com",
    "ChatModel": "generalv3.5"
  }
}
```

View Xunfei Spark's API Key:

![image-20240816101735673](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816101735673.png)

The key format is like this: APIKey:APISecret, which should be written in the form: 6d3...:M...:

![image-20240816102020096](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816102020096.png)

Validate if it is configured successfully:

![image-20240816102241575](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816102241575.png)

**LingYiWanWu**

Take the example of yi-large: 

```json
{
  "OpenAI": {
    "Key": "your key",
    "Endpoint": "https://api.lingyiwanwu.com",
    "ChatModel": "yi-large"
  }
}
```

Validate if it is configured successfully:

![image-20240816102914568](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816102914568.png)

If you found the information helpful, a star✨ would be the most significant support for me. 😊

If you've gone through the guide and are still facing issues, feel free to reach out to me via my WeChat Official Account:

![qrcode_for_gh_eb0908859e11_344](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/qrcode_for_gh_eb0908859e11_344.jpg)



