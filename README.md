# MSDNHackShanghai
MSDN New Home For Hack Shanghai Project

Date:2018/07/21

Description：使用PPT模块化对智能家居进行系统化管理

Technology Key Word：Azure-IoT,Microsoft-Cognitive-Service,Microsoft-Office,Microsoft-Azure,Microsoft-Flow,dotNet-Core,WeChat-Platform,Arduino


---- 
## 做的什么？

队名：MSP观光团

队员：李桑郁

项目概述：使用物联网与办公自动化，统一管理智能家居设备，与设计师、施工方共同建造你心中的家

#### 做物联设备的集线器

所有数据都以更简单的方式集合到一起，使用PowerPoint进行快速设计、展示，使用Excel使数据操作更加简单

#### 多人协作

多人协作、共同开发。Office365助力物联网开发设计。强大且简单的办公软件，使人人都容易上手。




## 第二部分

怎么做的

现在开始做吧

我想先做图集训练

还是先调整好Socket吧，最起码有个雏形才能开始动

##　资源索引

###计算机视觉识别物品并查找

计算机视觉Key2：5916dec9289e4f17b6d3a2a1a6b247f7

计算机视觉Host：https://eastus2.api.cognitive.microsoft.com/vision/v1.0

计算机视觉识别后Flow API：

POST /workflows/bd0434bd9e094105a9bc2644810bac75/triggers/manual/paths/invoke?api-version=2016-06-01&amp;sp=%2Ftriggers%2Fmanual%2Frun&amp;sv=1.0&amp;sig=24mvSH5194CeGouNg_kIpRxFAMZF7Q3wHYjw1Z83kCE HTTP/1.1
Host: prod-33.westus.logic.azure.com:443
Content-Type: application/json
Cache-Control: no-cache
Postman-Token: f78e017e-f75b-4ccb-9d98-a93ffc03e1a0

{
	"Name":"People",
    "Confidence":"0.99",
    "Hint":"sang"
}

微信配置：
服务器地址
http://gattia.azurewebsites.net/Wechat
Token（令牌）
GattiaSu

EncodingAESKey
0RS4qZN1Wcshydmx2BvJAJkFujiVISSLNwij3mH2yLw


微信Face Api
https://eastus2.api.cognitive.microsoft.com/face/v1.0
7d4007bbda084c91b3121a28409aca81

Bot API：https://hackshanghai.azurewebsites.net/api/messages


