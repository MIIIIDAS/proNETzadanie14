using System;
using System.IO;
using System.Security.Cryptography;

namespace RSACryptoTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "przykład.txt"; // Ścieżka do pliku do szyfrowania

            // Wygenerowanie par kluczy RSA
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Szyfrowanie pliku
                EncryptFile(filePath, rsa);

                // Deszyfrowanie pliku
                DecryptFile(Path.ChangeExtension(filePath, ".encrypted"), rsa);
            }
        }

        static void EncryptFile(string filePath, RSACryptoServiceProvider rsa)
        {
            // Odczytanie pliku do szyfrowania
            byte[] fileBytes = File.ReadAllBytes(filePath);

            // Szyfrowanie danych
            byte[] encryptedBytes = rsa.Encrypt(fileBytes, true);

            // Zapisanie zaszyfrowanych danych do nowego pliku
            string encryptedFilePath = Path.ChangeExtension(filePath, ".encrypted");
            File.WriteAllBytes(encryptedFilePath, encryptedBytes);

            Console.WriteLine("Plik zaszyfrowany: " + encryptedFilePath);
        }

        static void DecryptFile(string encryptedFilePath, RSACryptoServiceProvider rsa)
        {
            // Odczytanie zaszyfrowanego pliku
            byte[] encryptedBytes = File.ReadAllBytes(encryptedFilePath);

            // Deszyfrowanie danych
            byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, true);

            // Zapisanie odszyfrowanych danych do nowego pliku
            string decryptedFilePath = Path.ChangeExtension(encryptedFilePath, ".decrypted");
            File.WriteAllBytes(decryptedFilePath, decryptedBytes);

            Console.WriteLine("Plik odszyfrowany: " + decryptedFilePath);
        }
    }
}
