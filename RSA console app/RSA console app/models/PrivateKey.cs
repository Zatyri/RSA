using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA_console_app.models
{
    /// <summary>
    /// Class for private key
    /// </summary>
    public class PrivateKey
    {
        /// <summary>
        /// The private part of the key
        /// </summary>
        public BigInteger d { get; set; }
        /// <summary>
        /// The factor of the two primes used to create the public and private key
        /// </summary>
        public BigInteger n { get; set; }

        /// <summary>
        /// Constructor for private key
        /// </summary>
        /// <param name="d">The private part of the key</param>
        /// <param name="n">The factor of the two primes used to create the public and private key</param>
        public PrivateKey(BigInteger d, BigInteger n)
        {
            this.d = d;
            this.n = n;
        }
    }
}
