using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;

namespace TaskHub.Utils;

public class HashPasswords
{
    public static string EncoderPassword(string password)
    {
        var data = Encoding.ASCII.GetBytes(password);
        data = new System.Security.Cryptography.HMACMD5(data).ComputeHash(data);
        return data!.ToString()!;
    }
}