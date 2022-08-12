using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TestSDKSecurity : MonoBehaviour
{
    StringBuilder sb = new StringBuilder();
    void Start()
    {
        Logger("<br>-----------MD5加密---------------<br>");
        Logger(SDKSecurity.MD5Encrypt("仰天一笑"));

        Logger("<br>-----------DES加密---------------<br>");
        var desEncrypt = SDKSecurity.DESEncrypt("仰天一笑", "anson-xu");
        Logger(desEncrypt);
        Logger("<br>-----------DES解密---------------<br>");
        Logger(SDKSecurity.DESDecrypt(desEncrypt, "anson-xu"));

        Logger("<br>-----------AES加密---------------<br>");
        var aesEncrypt = SDKSecurity.AESEncrypt("仰天一笑", "anson-xu");
        Logger(aesEncrypt);
        Logger("<br>-----------AES解密---------------<br>");
        Logger(SDKSecurity.AESDecrypt(aesEncrypt, "anson-xu"));
        
        Debug.Log(sb.ToString());
    }

    void Logger(string str)
    {
        sb.Append(str);
        sb.Append("\n");
    }
    
    /* 输出结果
     
    <br>-----------MD5加密---------------<br>
    EE850F27E4DE05F6FDEB123A9893D02D
    <br>-----------DES加密---------------<br>
    /ctfiYZDm6TtrbxIEFt1HA==
    <br>-----------DES解密---------------<br>
    仰天一笑
    <br>-----------AES加密---------------<br>
    iek6ynHkE5oWeolupXsaqA==
    <br>-----------AES解密---------------<br>
    仰天一笑

    */
}
