using QuantumCSharp.Ibm;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace QuantumRandomNumbers
{
    public class QuantumRandomNumber
    {
        private short[] QuantumResults { get; set; }
        public IbmQX_SendResult IbmResult { get; set; }

        public void SetQuantumNumber(short[] Number)
        {
            this.QuantumResults = Number;
        }

        public Int64 ToInt64()
        {
            Int64 result = 0;
            for(int i = 0;i < QuantumResults.Length && i < 9;i++)
            {
                result += QuantumResults[i] * (Int64)Math.Pow(100, i);
            }
            return result;
        }

        public BigInteger ToBigInteger()
        {
            byte[] tmp_array = new byte[QuantumResults.Length];
            for (int i = 0; i < QuantumResults.Length; i++)
            {
                tmp_array[i] = (byte)QuantumResults[i];
            }
            return new BigInteger(tmp_array);
        }

        public override string ToString()
        {
            string new_format = "";
            for (int i = 0; i < QuantumResults.Length; i++)
            {
                new_format += QuantumResults[i] + (i < (QuantumResults.Length-1) ? " " : "");
            }
            return new_format;
        }
    }
}
