using System.Security.Cryptography;

namespace Hashing.Core
{
    /// <summary>
    /// Class for calculating MD5 hashes
    /// </summary>
    public class MD5Calculator : HashCalculatorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MD5Calculator"/> class.
        /// </summary>
        /// <param name="filePath">Target file for calculation</param>
        public MD5Calculator(string filePath) : base(filePath)
        {

        }

        /// <summary>
        /// A method for creating a readable hash string
        /// </summary>
        /// <returns></returns>
        public override string Calculate()
        {
            string output = null;

            using (MD5 mD5 = MD5.Create())
            {
                output = GetHash(mD5);
            }

            return output;
        }
    }
}
