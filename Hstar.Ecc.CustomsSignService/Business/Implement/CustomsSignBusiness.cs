using System.Threading.Tasks;
using Hstar.Ecc.CustomsSignService.Config;
using Hstar.Ecc.CustomsSignService.Model;
using Hstar.Ecc.CustomsSignService.SignSdk;

namespace Hstar.Ecc.CustomsSignService.Business.Implement
{
    public class CustomsSignBusiness : ICustomsSignBusiness
    {
        public async Task<CertNoResponse> GetCertNoAsync()
        {
            var certNo = CustomsSignSdk.GetCertNo();
            return await Task.Run(() => new CertNoResponse { CertNo = certNo });
        }

        public async Task<CertResponse> GetCertAsync()
        {
            var cert = CustomsSignSdk.GetCardID();
            return await Task.Run(() => new CertResponse { Cert = cert });
        }

        public async Task<SignResponse> SignAsync(SignRequest signReq)
        {
            var result = CustomsSignSdk.Sign(signReq.Content, AppConfig.UKeyPassword);
            return await Task.Run(() => new SignResponse { Content = signReq.Content, SignResult = result });
        }
    }
}
