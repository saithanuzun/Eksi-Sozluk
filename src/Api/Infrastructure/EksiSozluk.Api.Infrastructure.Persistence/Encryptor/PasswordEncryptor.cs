using System.Security.Cryptography;
using System.Text;

namespace EksiSozluk.Api.Infrastructure.Persistence.Encryptor;

public class PasswordEncryptor
{
    public static string Encrypt(string password)
    {
        using (var md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}