using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Hstar.Ecc.CustomsSignService.SignSdk
{
    public class CustomsSignSdk
    {
        const int SIGN_SUCCESS = 0;

        [DllImport("usercard_cert64\\Sign64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCardID([MarshalAs(UnmanagedType.LPArray)] byte[] szCardID, ref uint nCardIDLen);

        /// <summary>
        /// 获取证书（卡号）
        /// </summary>
        /// <returns></returns>
        public static string GetCardID()
        {
            uint dataLen = 2000;
            var dataArr = new byte[dataLen];
            var ret = GetCardID(dataArr, ref dataLen);
            if (ret == SIGN_SUCCESS)
            {
                return Encoding.UTF8.GetString(dataArr, 0, (int)dataLen);
            }
            throw new Exception($"Get card id failed, error code: {ret}");
        }

        [DllImport("usercard_cert64\\Sign64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCertNo([MarshalAs(UnmanagedType.LPArray)] byte[] szCertNo, ref uint nCertNoLen);

        /// <summary>
        /// 获取证书编号
        /// </summary>
        /// <returns></returns>
        public static string GetCertNo()
        {
            uint dataLen = 100;
            var dataArr = new byte[dataLen];
            var ret = GetCertNo(dataArr, ref dataLen);
            if (ret == SIGN_SUCCESS)
            {
                return Encoding.UTF8.GetString(dataArr, 0, (int)dataLen);
            }
            throw new Exception($"Get cert NO. failed, error code: {ret}");
        }

        /// <summary>
        /// 用加密设备传入报文进行加签
        /// </summary>
        /// <param name="src">【in】src 待签名的原始数据</param>
        /// <param name="srcLen">【in】srcLen 待签名的原始数据的长度</param>
        /// <param name="sign">【out】sign签名数据(至少分配128字节)，!!固定分配172字节!!</param>
        /// <param name="signLen">【in，out】signLen 签名数据长度，应大于128个字节，输入时应等于szSignData实际分配的空间大小</param>
        /// <param name="pwd">【in】pwd	进行加签的卡密码</param>
        /// <returns></returns>
        [DllImport("usercard_cert64\\Sign64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Sign([MarshalAs(UnmanagedType.LPArray)] byte[] src, uint srcLen, [MarshalAs(UnmanagedType.LPArray)] byte[] sign, ref uint signLen, string pwd);

        /// <summary>
        /// 用加密设备传入报文进行加签
        /// </summary>
        /// <param name="text"></param>
        /// <param name="password">UKey的密码</param>
        /// <returns></returns>
        public static string Sign(string text, string password)
        {
            var textBytes = Encoding.UTF8.GetBytes(text);
            uint signLen = 172; // 签名的固定长度
            var signBytes = new byte[signLen];
            var ret = Sign(textBytes, (uint)textBytes.Length, signBytes, ref signLen, password);
            if (ret == SIGN_SUCCESS)
            {
                return Encoding.UTF8.GetString(signBytes, 0, (int)signLen);
            }
            throw new Exception($"Sign failed, error code: {ret}");
        }
    }
}
