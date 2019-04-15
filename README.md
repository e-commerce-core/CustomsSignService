# CustomsSignService
The customs sign service. 

# 签名注意事项

1. 需要用 Administrator 权限启动 Visual Studio （读取UKey）
2. 获取证书API当前无法返回证书内容，原因未知，待查。
3. 在发布时，确保把项目下的 `usercard_cert64` 目录全部拷贝到发布目录（开发模式下不需要，已经配置自动拷贝）。

# API List

开发模式 ApiHost(IIS Express): http://localhost:62464/ ApiHost(SelfHost) http://localhost:5000/

### 获取证书编号API

```
GET /customs-sign/v1/cert-no

Response Body: {
	certNo: "0135ddxx"
}
```

### 获取证书

```
GET /customs-sign/v1/cert

Response Body: {
	cert: ""
}
```

**注意：当前该接口无法获取到数据，原因未知**

### 使用证书进行签名

```
POST /customs-sign/v1/sign

Request Headers：{
	"Content-Type": "application/json"
}

Request Body: {
	"Content": "要签名的内容" 
}

Response Body: {
    "content": "要签名的内容",
    "signResult": "签名后的内容"
}

```

# 报关注意事项

1. 证书编号，使用 signtool 获取到的是大写，但是注册和推送海关的时候，一定要使用全小写的证书编号。
2. 海关请求我们的时候，Method = POST，Content-Type = application.x-www-form-urlencoded，所以必须要从 Request Body 中获取数据，且数据 Key = openReq。如：
```
openReq={"sessionID":"fe2374-8fnejf97-55616242","orderNo":"订单号","serviceTime":"1544519952469"}
```
3. 金额必须是数字类型，不能是字符串（不需要带双引号）；值的零尾巴需要截取掉。

| 错误格式 | 正确格式 |
| --- | --- |
| 100.0 | 100 |
| 100.10 | 100.1 |

# 其他信息

如果还遇到有其他问题，可以参考下： https://github.com/CooperLiu/CustomsReport 
