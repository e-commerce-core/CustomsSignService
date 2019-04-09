# CustomsSignService
The customs sign service. 

# 注意事项

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