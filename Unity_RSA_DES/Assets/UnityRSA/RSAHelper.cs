using System.IO;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class RSAHelper
{
    /// <summary>
    /// 生成RSA公钥和私钥，并存储到streamingAssets目录下
    /// </summary>
    public static void GenerateKeys()
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        var privateKey = rsa.ToXmlString(true);
        var publicKey = rsa.ToXmlString(false);
        var path = Application.streamingAssetsPath + "/RSA";
        File.WriteAllText(path + "/privateKey.xml", privateKey);
        File.WriteAllText(path + "/publicKey.xml", publicKey);
        AssetDatabase.Refresh();
    }
    
    /// <summary>
    /// RSA 加密
    /// </summary>
    /// <param name="data"></param>
    /// <param name="publicKey"></param>
    /// <returns></returns>
    public static byte[] Encrypt(byte[] data, string publicKey)
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(publicKey);
        byte[] encryptData = rsa.Encrypt(data, false);
        return encryptData;
    }
    
    /// <summary>
    /// RSA 解密
    /// </summary>
    /// <param name="data"></param>
    /// <param name="privateKey"></param>
    /// <returns></returns>
    public static byte[] Decrypt(byte[] data, string privateKey)
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(privateKey);
        byte[] decryptData = rsa.Decrypt(data, false);
        return decryptData;
    }
}
