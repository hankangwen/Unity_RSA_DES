/**************************
 * 文件名:Test.cs;
 * 文件描述:
 *  1.客户端生成RSA公钥 私钥，公钥发给服务器，
 *  2.服务器生成DES密钥，并用公钥加密后发给客户端，
 *  3.客户端用私钥解密得到DES密钥
 *  4.客户端服务器用DES密钥加密解密传输数据
 * 创建日期:2022/08/11;
 * Author:hankangwen;
 * Page:https://github.com/getker/Unity_RSA_DES
 ***************************/

using System.Text;
using UnityEngine;

public class Test : MonoBehaviour
{
    public string message = "Hello World";
    private string privateKey = string.Empty;
    private string publicKey = string.Empty;
    
    void Start()
    {
        message = SystemInfo.deviceUniqueIdentifier;
        Debug.Log("src:" + message);
        byte[] data = Encoding.Default.GetBytes(message);   //网络数据包
        
        //1、客户端 -- 生成RSA公钥 私钥，并把公钥发给服务器
        UEncrypt.RSAGenerateKey(ref privateKey, ref publicKey);
        
        //2、服务端 -- 生成DES密钥
        byte[] serverDesKey = new byte[] {1, 2, 3, 4, 8, 7, 6, 5};
        
        //3、服务端 -- 用RSA公钥加密 DES密钥，并发给客户端
        byte[] serverDesKeyEncrypt = UEncrypt.RSAEncrypt(serverDesKey, publicKey);
        
        //4、客户端 -- 用RSA私钥解密 DES密钥
        byte[] clientRsaDecryptDesKey = UEncrypt.RSADecrypt(serverDesKeyEncrypt, privateKey);
        
        //5、客户端 -- 用 DES密钥加密网络包
        byte[] clientDesEncryptData = UEncrypt.DESEncrypt(data, clientRsaDecryptDesKey, clientRsaDecryptDesKey);
        
        //6、服务端 -- 用 DES密钥解密网络包
        byte[] serverDesDecryptData = UEncrypt.DESDecrypt(clientDesEncryptData, serverDesKey, serverDesKey);
        
        message = Encoding.Default.GetString(serverDesDecryptData);
        Debug.Log("des:" + message);
    }
}
