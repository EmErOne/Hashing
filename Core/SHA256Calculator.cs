using System.Security.Cryptography;

namespace Hashing.Core
{
    /// <summary>
    /// Class for calculating SHA256 hashes
    /// </summary>
    public class SHA256Calculator : HashCalculatorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SHA256Calculator"/> class.
        /// </summary>
        /// <param name="filePath">Target file for calculation</param>
        public SHA256Calculator(string filePath) : base(filePath)
        {

        }

        /// <summary>
        /// A method for creating a readable hash string
        /// </summary>
        /// <returns></returns>
        public override string Calculate()
        {
            string output = null;

            using (SHA256 sHA256 = SHA256.Create())
            {
                output = GetHash(sHA256);
            }

            return output;
        }
    }
}
