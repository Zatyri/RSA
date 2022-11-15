using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA_console_app.models
{
    public class PublicKey
    {
        public BigInteger n { get; set; }
        public BigInteger e { get; set; }
        public BigInteger phi { get; set; }

        public PublicKey(BigInteger n, BigInteger e, BigInteger phi)
        {
            this.n = n;
            this.e = e;
            this.phi = phi;
        }
    }
}
