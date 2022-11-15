using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA_console_app.models
{
    /// <summary>
    /// Class for the public key
    /// </summary>
    public class PublicKey
    {
        /// <summary>
        /// The factor of the two primes used to create public and private key
        /// </summary>
        public BigInteger n { get; set; }
        /// <summary>
        /// A integer not a factor of n
        /// </summary>
        public BigInteger e { get; set; }
        /// <summary>
        /// The value used to determine e and used in private key generation
        /// </summary>
        public BigInteger phi { get; set; }
        /// <summary>
        /// Constructor for the public key
        /// </summary>
        /// <param name="n">The factor of the two primes used to create public and private key</param>
        /// <param name="e">A integer not a factor of n</param>
        /// <param name="phi">The value used to determine e and used in private key generation</param>
        public PublicKey(BigInteger n, BigInteger e, BigInteger phi)
        {
            this.n = n;
            this.e = e;
            this.phi = phi;
        }
    }
}
