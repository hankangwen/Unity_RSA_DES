using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class UnityRSA : MonoBehaviour
{
    public string message = "Hello World";
    
    void Start()
    {
        var path = Application.streamingAssetsPath + "/RSA/";
        var privateKey = File.ReadAllText(path + "privateKey.xml");
        var publicKey = File.ReadAllText(path + "publicKey.xml");
        
        message = SystemInfo.deviceUniqueIdentifier;    //获取电脑id
        Debug.Log("src:" + message);
        byte[] data = Encoding.Default.GetBytes(message);

        byte[] encryptData = RSAHelper.Encrypt(data, publicKey);
        byte[] decryptData = RSAHelper.Decrypt(encryptData, privateKey);
        
        string decryptMessage = Encoding.Default.GetString(decryptData);
        Debug.Log("dst:" + decryptMessage);
    }
}
