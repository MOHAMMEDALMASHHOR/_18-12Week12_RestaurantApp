using System.Security.Cryptography;
using System.Text;

public static class StringEndocer
{
    public static string Encoder(this string password, int salt){
        byte[] data = Encoding.UTF8.GetBytes(password+salt.ToString());
        byte[] hash = SHA256.HashData(data);
        return Convert.ToHexString(hash);
    }
}