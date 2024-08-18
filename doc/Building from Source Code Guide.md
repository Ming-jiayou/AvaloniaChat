# Building from Source Code

Clone the project to your local machine using git and open the sln file in Visual Studio:

![image-20240818124119748](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240818124119748.png)

IDE: VS2022

.NET Version: .NET 8

Running directly will result in an error:

![image-20240818124321859](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240818124321859.png)

This is because the appsettings.json file contains sensitive information such as the API Key for the large language model, which I have not uploaded to GitHub. However, I have uploaded a sppsettings.example.json file, which looks like this:

![](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240818124513719.png)

Create a new appsettings.json file and write the following content:

![image-20240818124600882](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240818124600882.png)

Set AvaloniaChat.Demo as the startup project:

![image-20240818124627833](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240818124627833.png)

Run the program:

![image-20240818124808202](https://mingupupup.oss-cn-wuhan-lr.aliyuncs.com/imgs/image-20240818124808202.png)

Successfully built and ran from the source code.