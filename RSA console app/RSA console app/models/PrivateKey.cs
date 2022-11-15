using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA_console_app.models
{
    public class PrivateKey
    {
        public BigInteger d { get; set; }
        public BigInteger n { get; set; }

        public PrivateKey(BigInteger d, BigInteger n)
        {
            this.d = d;
            this.n = n;
        }
    }
}
