using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hstar.Ecc.CustomsSignService.Business;
using Hstar.Ecc.CustomsSignService.Model;
using Microsoft.AspNetCore.Mvc;

namespace Hstar.Ecc.CustomsSignService.Controllers
{
    [Route("customs-sign/v1")]
    [ApiController]
    public class CustomsSignController : ControllerBase
    {
        private readonly ICustomsSignBusiness customsSignBiz;
        public CustomsSignController(ICustomsSignBusiness customsSignBiz)
        {
            this.customsSignBiz = customsSignBiz;
        }

        /// <summary>
        /// 获取证书
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("cert")]
        public async Task<string> GetCertAsync()
        {
            return await this.customsSignBiz.GetCertAsync();
        }

        /// <summary>
        /// 获取证书序列号
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("cert-no")]
        public async Task<string> GetCertNoAsync()
        {
            return await this.customsSignBiz.GetCertNoAsync();
        }

        /// <summary>
        /// 执行签名
        /// </summary>
        /// <param name="signReq"></param>
        /// <returns></returns>
        [HttpPost, Route("sign")]
        public async Task<string> SignAsync([FromBody]SignRequest signReq)
        {
            return await this.customsSignBiz.SignAsync(signReq);
        }
    }
}
