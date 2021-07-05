using System;
using System.Text;
using System.Collections.Generic;
using Nethereum.KeyStore;
using Nethereum.Signer;
using System.IO;

namespace EthRegger
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "wallets.csv";
            List<string> addresses = new List<string>();
            List<string> privateKeys = new List<string>();
            string privateKey, address;
            int amount;
            EthECKey key;

            Console.WriteLine("ETH Wallets amount :");

            while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Please enter the number:");
            }

            for (int i = 0; i < amount; i++)
            {
                key = EthECKey.GenerateKey();
                privateKey = BitConverter.ToString(key.GetPrivateKeyAsBytes()).Replace("-", "").ToLower();
                address = key.GetPublicAddress();

                addresses.Add(address);
                privateKeys.Add(privateKey);
            }

            for (int i = 0; i < amount; i++)
            {
                File.AppendAllText(path, addresses[i] + "," + privateKeys[i] + "\n", Encoding.UTF8);
            }

            //json file for Mist
            //string password = @":0dmY0!&lKb{[HQ2_Xxc";
            //byte[] privateKey = key.GetPrivateKeyAsBytes();
            //var keyStore = new KeyStoreScryptService();
            //string json = keyStore.EncryptAndGenerateKeyStoreAsJson(
            //   password: password,
            //   privateKey: privateKey,
            //   addresss: address);
        }
    }
}
