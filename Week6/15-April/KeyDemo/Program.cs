using System.Net;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using System.Text;

namespace KeyDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var credential = new DefaultAzureCredential();

        string vaultUrl = "";
        string keyName = "CgKey";

        var keyClient = new KeyClient(new Uri(vaultUrl), credential);

        KeyVaultKey key = (await keyClient.GetKeyAsync(keyName)).Value;

        string originalText = "Sensitive order data for CloudXeus Technology Services";
        byte[] plaintextBytes = Encoding.UTF8.GetBytes(originalText);

        var cryptoClient = new CryptographyClient(key.Id, credential);

        EncryptResult encryptResult = await cryptoClient.EncryptAsync(
            EncryptionAlgorithm.RsaOaep,
            plaintextBytes);

        Console.WriteLine("Encrypted text (Base64):");
            Console.WriteLine(Convert.ToBase64String(encryptResult.Ciphertext));

            DecryptResult decryptResult = await cryptoClient.DecryptAsync(
                EncryptionAlgorithm.RsaOaep,
                encryptResult.Ciphertext);

        string decryptedText = Encoding.UTF8.GetString(decryptResult.Plaintext);

        Console.WriteLine("\nDecrypted text:");
            Console.WriteLine(decryptedText);

            Console.ReadLine();
        }
}
}
