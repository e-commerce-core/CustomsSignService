using Hstar.Ecc.CustomsSignService.Model;
using System.Threading.Tasks;

namespace Hstar.Ecc.CustomsSignService.Business
{
    public interface ICustomsSignBusiness
    {
        /// <summary>
        /// 执行签名
        /// </summary>
        /// <param name="signReq"></param>
        /// <returns></returns>
        Task<SignResponse> SignAsync(SignRequest signReq);

        /// <summary>
        /// 获取证书
        /// </summary>
        /// <returns></returns>
        Task<CertResponse> GetCertAsync();

        /// <summary>
        /// 获取证书序列号
        /// </summary>
        /// <returns></returns>
        Task<CertNoResponse> GetCertNoAsync();
    }
}
