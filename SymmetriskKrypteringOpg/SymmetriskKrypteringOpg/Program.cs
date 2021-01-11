using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetriskKrypteringOpg
{
    class Program
    {
        static void Main(string[] args)
        {
            Encryption encryption = new Encryption();
            Console.WriteLine("Please choose your way of encrypting:");
            Console.WriteLine("(1) DES");
            Console.WriteLine("(2) TripleDES");
            Console.WriteLine("(3) Rijndael");
            int chosenEncr = int.Parse(Console.ReadLine());
            encryption.GenerateSymmetricAlg(chosenEncr);
            Console.WriteLine("Please write your message:");
            string message = Console.ReadLine();
            
            switch (chosenEncr)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Encryption with DES");
                    Console.WriteLine("Message in plaintext: " + message);
                    byte[] encryptedDESMsg = encryption.Encrypt(Encoding.ASCII.GetBytes(message));
                    Console.WriteLine("Encrypted message: " + Convert.ToBase64String(encryptedDESMsg));
                    Console.WriteLine("Decrypted message: " + Convert.ToBase64String(encryption.Decrypt(encryptedDESMsg)));
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Encryption with TripleDES");
                    byte[] encryptedTripleDESMsg = encryption.Encrypt(Encoding.ASCII.GetBytes(message));
                    Console.WriteLine("Encrypted message: " + Convert.ToBase64String(encryptedTripleDESMsg));
                    Console.WriteLine("Decrypted message: " + Convert.ToBase64String(encryption.Decrypt(encryptedTripleDESMsg)));
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Encryption with Rijndael");
                    byte[] encryptedRijndaelMsg = encryption.Encrypt(Encoding.ASCII.GetBytes(message));
                    Console.WriteLine("Encrypted message: " + Convert.ToBase64String(encryptedRijndaelMsg));
                    Console.WriteLine("Decrypted message: " + Convert.ToBase64String(encryption.Decrypt(encryptedRijndaelMsg)));
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }
    }
}
