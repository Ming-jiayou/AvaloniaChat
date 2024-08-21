# AvaloniaChat-v0.0.2：兼容智谱AI 快速使用指南

## 智谱AI介绍

北京智谱华章科技有限公司（简称“智谱AI”）致力于打造新一代认知智能大模型，专注于做大模型的中国创新。公司合作研发了中英双语千亿级超大规模预训练模型GLM-130B，并基于此推出对话模型ChatGLM，开源单卡版模型ChatGLM-6B。同时，团队还打造了AIGC模型及产品矩阵，包括AI提效助手智谱清言（[chatglm.cn](https://chatglm.cn/)）、高效率代码模型CodeGeeX、多模态理解模型CogVLM和文生图模型CogView等。公司践行Model as a Service（MaaS）的市场理念，推出大模型MaaS开放平台（https://open.bigmodel.cn/），打造高效率、通用化的“模型即服务”AI开发新范式。通过认知大模型链接物理世界的亿级用户，智谱AI基于完整的模型生态和全流程技术支持，为千行百业带来持续创新与变革，加速迈向通用人工智能的时代。

![image-20240821090355855](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240821090355855.png)

## AvaloniaChat介绍

**一个使用大型语言模型进行翻译的简单应用。**

**我自己的主要使用场景**

在看英文文献的过程中，比较喜欢对照着翻译看，因此希望一边是英文一边是中文，虽然某些软件已经自带了翻译功能，但还是喜欢大语言模型的翻译，但每次都要将英文复制粘贴过去还要自己手动添加prompt，还无法对照着看，因此自己基于Avalonia与Semantic Kernel开发了这款解决自己这个需求的软件，开源出来每个人都可以免费使用，希望能帮助到有同样需求的人。

GitHub地址：https://github.com/Ming-jiayou/AvaloniaChat

## 快速开始指南

点击Releases这的AvaloniaChat-v0.0.2：

![image-20240821083729188](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240821083729188.png)

点击zip文件即可下载：

![image-20240821083914876](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240821083914876.png)

解压之后，如下所示：

![image-20240821084023308](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240821084023308.png)

打开appsettings.json文件，填入智谱AI的Api Key即可：

![image-20240821084111037](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240821084111037.png)

如果选择其他兼容OpenAI格式的平台，Platform可不填。

智谱AI目前注册可获得2500万Tokens，但是一个月就过期了。

点击exe文件，皆可使用软件：

![image-20240821084436247](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240821084436247.png)

验证是否设置成功：

![image-20240821084519660](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240821084519660.png)

开始使用：

![image-20240821085009018](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240821085009018.png)

![image-20240821085102315](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240821085102315.png)