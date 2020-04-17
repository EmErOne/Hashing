using System.Security.Cryptography;

namespace Hashing.Core
{
    /// <summary>
    /// Class for calculating SHA512 hashes
    /// </summary>
    public class SHA512Calculator : HashCalculatorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SHA512Calculator"/> class.
        /// </summary>
        /// <param name="filePath">Target file for calculation</param>
        public SHA512Calculator(string filePath) : base(filePath)
        {

        }

        /// <summary>
        /// A method for creating a readable hash string
        /// </summary>
        /// <returns></returns>
        public override string Calculate()
        {
            string output = null;

            using (SHA512 sHA512 = SHA512.Create())
            {
                output = GetHash(sHA512);
            }

            return output;
        }
    }
}
