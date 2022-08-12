using UnityEditor;

public class RSATool
{
    [MenuItem("Tools/RSA/Generate Key")]
    public static void GenerateKeys()
    {
        RSAHelper.GenerateKeys();
    }
}