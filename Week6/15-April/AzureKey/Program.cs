using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Storage.Blobs;

namespace ImageEncryptDecrypt
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // ==============================
            // Azure Configuration
            // ==============================
            string vaultUrl = "";
            string keyName = "CgKey";

            string storageUrl = "";
            string containerName = "encrypted-images";

            // ==============================
            // Local File Paths
            // ==============================
            string inputImagePath = @"C:\Users\Aman Anand\source\repo\Week6\15-April\AzureKey\Images\input.jpeg";
            string outputImagePath = @"C:\Users\Aman Anand\source\repo\Week6\15-April\AzureKey\Images\output.jpeg";

            // Blob file names
            string encryptedBlobName = "image.enc";
            string encryptedKeyBlobName = "key.enc";
            string ivBlobName = "iv.bin";

            try
            {
                // Passwordless Azure login
                var credential = new DefaultAzureCredential();

                // ==============================
                // Get RSA key from Azure Key Vault
                // ==============================
                var keyClient = new KeyClient(new Uri(vaultUrl), credential);
                KeyVaultKey key = (await keyClient.GetKeyAsync(keyName)).Value;

                var cryptoClient = new CryptographyClient(key.Id, credential);

                // ==============================
                // Read image from local path
                // ==============================
                byte[] imageBytes = File.ReadAllBytes(inputImagePath);

                // ==============================
                // AES Encryption
                // ==============================
                using Aes aes = Aes.Create();
                aes.GenerateKey();
                aes.GenerateIV();

                byte[] encryptedImage;

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(
                    ms,
                    aes.CreateEncryptor(),
                    CryptoStreamMode.Write))
                {
                    cs.Write(imageBytes, 0, imageBytes.Length);
                    cs.FlushFinalBlock();
                    encryptedImage = ms.ToArray();
                }

                // ==============================
                // Encrypt AES key using RSA Key Vault key
                // ==============================
                EncryptResult encryptedKey = await cryptoClient.EncryptAsync(
                    EncryptionAlgorithm.RsaOaep,
                    aes.Key);

                // ==============================
                // Upload encrypted files to Blob Storage
                // ==============================
                var container = new BlobContainerClient(
                    new Uri($"{storageUrl}{containerName}"),
                    credential);

                await container.CreateIfNotExistsAsync();

                await container.GetBlobClient(encryptedBlobName)
                    .UploadAsync(new MemoryStream(encryptedImage), overwrite: true);

                await container.GetBlobClient(encryptedKeyBlobName)
                    .UploadAsync(new MemoryStream(encryptedKey.Ciphertext), overwrite: true);

                await container.GetBlobClient(ivBlobName)
                    .UploadAsync(new MemoryStream(aes.IV), overwrite: true);

                Console.WriteLine("✅ Image encrypted and uploaded successfully.");

                // ==============================
                // Download encrypted files
                // ==============================
                byte[] downloadedImage =
                    (await container.GetBlobClient(encryptedBlobName)
                    .DownloadContentAsync()).Value.Content.ToArray();

                byte[] downloadedKey =
                    (await container.GetBlobClient(encryptedKeyBlobName)
                    .DownloadContentAsync()).Value.Content.ToArray();

                byte[] downloadedIV =
                    (await container.GetBlobClient(ivBlobName)
                    .DownloadContentAsync()).Value.Content.ToArray();

                // ==============================
                // Decrypt AES key using Key Vault
                // ==============================
                DecryptResult decryptedKey = await cryptoClient.DecryptAsync(
                    EncryptionAlgorithm.RsaOaep,
                    downloadedKey);

                // ==============================
                // AES Decryption
                // ==============================
                using Aes aesDecrypt = Aes.Create();
                aesDecrypt.Key = decryptedKey.Plaintext;
                aesDecrypt.IV = downloadedIV;

                byte[] decryptedImage;

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(
                    ms,
                    aesDecrypt.CreateDecryptor(),
                    CryptoStreamMode.Write))
                {
                    cs.Write(downloadedImage, 0, downloadedImage.Length);
                    cs.FlushFinalBlock();
                    decryptedImage = ms.ToArray();
                }

                // ==============================
                // Save decrypted image locally
                // ==============================
                File.WriteAllBytes(outputImagePath, decryptedImage);

                Console.WriteLine("✅ Image decrypted and saved successfully.");
                Console.WriteLine($"📁 Output Path: {outputImagePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error:");
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}