using System.Security.Cryptography;
using System.Text;

namespace Auth.Infrastruture.CrossCutting.Helper;

public static class PasswordHelper
{
    public static string GenerateCodeLettersNumber()
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var data = new byte[1];
        using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
        {
            crypto.GetNonZeroBytes(data);
            data = new byte[6];
            crypto.GetNonZeroBytes(data);
        }
        var result = new StringBuilder(6);
        foreach (byte b in data)
        {
            result.Append(chars[b % (chars.Length)]);
        }
        return result.ToString();
    }

    public static int GenerateCodeNumber()
    {
        var random = new RNGCryptoServiceProvider();
        var data = new byte[4];
        random.GetBytes(data);
        return BitConverter.ToInt32(data, 0);
    }

    public static string GeneratePassword()
    {
        var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+";
        var random = new RNGCryptoServiceProvider();
        var data = new byte[4];
        random.GetBytes(data);
        var result = new StringBuilder(8);
        for (int i = 0; i < 8; i++)
        {
            var rnd = BitConverter.ToUInt32(data, 0) % (uint)chars.Length;
            result.Append(chars[(int)rnd]);
            random.GetBytes(data);
        }
        return result.ToString();
    }

    public static string GetSha256Hash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

}
