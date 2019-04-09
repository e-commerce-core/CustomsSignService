# CustomsSignService
The customs sign service. 

# 注意事项

1. 需要用 Administrator 权限启动 Visual Studio （读取UKey）
2. 获取证书API当前无法返回证书内容，原因未知，待查。

# API List

开发模式 ApiHost(IIS Express): http://localhost:62464/ ApiHost(SelfHost) http://localhost:5000/

### 获取证书编号API

```
GET /customs-sign/v1/cert-no
```

### 获取证书

```
GET /customs-sign/v1/cert
```

### 使用证书进行签名

```
POST /customs-sign/v1/sign

Request Headers：{
	"Content-Type": "application/json"
}

Request Body: {
	"Content": "要签名的内容" 
}

```