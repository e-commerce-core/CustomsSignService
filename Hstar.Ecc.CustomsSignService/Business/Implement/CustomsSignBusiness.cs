using System.Threading.Tasks;
using Hstar.Ecc.CustomsSignService.Config;
using Hstar.Ecc.CustomsSignService.Model;
using Hstar.Ecc.CustomsSignService.SignSdk;

namespace Hstar.Ecc.CustomsSignService.Business.Implement
{
    public class CustomsSignBusiness : ICustomsSignBusiness
    {
        public async Task<string> GetCertNoAsync()
        {
            var result = CustomsSignSdk.GetCertNo();
            return await Task.Run(() => result);
        }

        public async Task<string> GetCertAsync()
        {
            var result = CustomsSignSdk.GetCardID();
            return await Task.Run(() => result);
        }

        public async Task<string> SignAsync(SignRequest signReq)
        {
            var result = CustomsSignSdk.Sign(signReq.Content, AppConfig.UKeyPassword);
            return await Task.Run(() => result);
        }
    }
}
