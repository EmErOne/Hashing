using System;
using System.IO;
using System.Security.Cryptography;

namespace Hashing.Core
{
    /// <summary>
    /// Basic class for calculating hashes
    /// </summary>
    public abstract class HashCalculatorBase
    {
        /// <summary>
        /// Target file for calculation
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashCalculatorBase"/> class.
        /// </summary>
        /// <param name="filePath">Target file for calculation</param>
        protected HashCalculatorBase(string filePath)
        {
            FilePath = filePath;
        }

        /// <summary>
        /// Generates a hash in the desired format
        /// </summary>
        /// <param name="hashAlgorithm">Target HashAlgorithm</param>
        /// <returns></returns>
        protected string GetHash(HashAlgorithm hashAlgorithm)
        {
            string output = null;

            FileInfo fInfo = new FileInfo(FilePath);
            FileStream fileStream = null;
            try
            {
                fileStream = fInfo.Open(FileMode.Open);
                fileStream.Position = 0;
                byte[] hashValue = hashAlgorithm.ComputeHash(fileStream);
                hashAlgorithm.Dispose();
                output = ConvertByteArray(hashValue);
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

            return output;
        }

        /// <summary>
        /// A method for displaying the generated hash in a legible manner.
        /// </summary>
        /// <param name="array">Hash DataArry</param>
        /// <returns></returns>
        protected static string ConvertByteArray(byte[] array)
        {
            string output = string.Empty;

            for (int i = 0; i < array.Length; i++)
            {
                output += ($"{array[i]:X2}");

                if ((i % 4) == 3)
                {
                    output += (" ");
                }
            }

            return output;
        }

        /// <summary>
        /// A method for creating a readable hash string
        /// </summary>
        /// <returns></returns>
        public abstract string Calculate();
    }
}
