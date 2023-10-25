using System.Security.Cryptography;

namespace Conesoft.Website.CDN;

public class Helpers
{
    public static string CalculateMD5(string filename)
    {
        using var md5 = MD5.Create();
        using var stream = File.OpenRead(filename);
        return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
    }
}
