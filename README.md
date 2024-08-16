# AvaloniaChat：一个基于大语言模型用于翻译的简单应用
## 简介

**一个使用大型语言模型进行翻译的简单应用。**

**A simple application using a large language model for translation.**

## 使用指南

### 非程序员朋友

#### 安装

访问GitHub地址：https://github.com/Ming-jiayou/AvaloniaChat

注意到Releases这里：

![image-20240816093724343](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816093724343.png)

点击AvaloniaChat-v0.0.1-win-x64.zip就会在下载了：

![image-20240816093952249](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816093952249.png)

解压之后，打开文件夹，如下所示：

![image-20240816094206770](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816094206770.png)

#### 使用

现在只需简单编辑一下appsettings.json文件，该文件用于配置你所使用的大语言模型。

以硅基流动为例，也最推荐硅基流动，Qwen/Qwen2-7B-Instruct是免费的，并且推理速度很快。

注册硅基流动之后，创建一个Api Key，复制这个Api Key：

![image-20240816094640258](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816094640258.png)

打开appsettings.json文件，如果使用的是硅基流动，只需填入Api Key即可：

![image-20240816094800525](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816094800525.png)

现在配置就完成了，点击exe文件即可使用：

![image-20240816094827621](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816094827621.png)

问AI问题：

![](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/AvaloniaChat-v0.0.1.gif)

![image-20240816095611412](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816095611412.png)

**个人的主要使用场景**

在看英文文献的过程中，比较喜欢对照着翻译看，因此希望一边是英文一边是中文，虽然某些软件已经自带了翻译功能，但还是喜欢大语言模型的翻译，但每次都要将英文复制粘贴过去还要自己手动添加prompt，还无法对照着看，因此自己基于Avalonia与Semantic Kernel开发了这款解决自己这个需求的软件，开源出来每个人都可以免费使用，希望能帮助到有同样需求的人。

英译中：

![](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/AvaloniaChat-v0.0.1-2.gif)

![image-20240816100534403](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816100534403.png)

中译英：

![](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/AvaloniaChat-v0.0.1-3.gif)

![image-20240816100742362](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816100742362.png)

#### 配置其他大语言模型

**讯飞星火**

以Spark Max为例，appsettings.json文件这样写：

```json
{
  "OpenAI": {
    "Key": "your key",
    "Endpoint": "https://spark-api-open.xf-yun.com",
    "ChatModel": "generalv3.5"
  }
}
```

查看讯飞星火的Api Key：

![image-20240816101735673](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816101735673.png)

讯飞星火的key是这样的 APIKey:APISecret，需要写成6d3...:M...这样的形式：

![image-20240816102020096](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816102020096.png)

验证是否配置成功：

![image-20240816102241575](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816102241575.png)

**零一万物**

以yi-large为例：

```json
{
  "OpenAI": {
    "Key": "your key",
    "Endpoint": "https://api.lingyiwanwu.com",
    "ChatModel": "yi-large"
  }
}
```

验证是否配置成功：

![image-20240816102914568](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240816102914568.png)

## 最后

如果对你有所帮助，点个Star✨，就是最大的支持😊。

如果您看了指南，还是遇到了问题，欢迎通过我的公众号联系我：

![](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/%E6%89%AB%E7%A0%81_%E6%90%9C%E7%B4%A2%E8%81%94%E5%90%88%E4%BC%A0%E6%92%AD%E6%A0%B7%E5%BC%8F-%E7%99%BD%E8%89%B2%E7%89%88.png)



