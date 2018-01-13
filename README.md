# QuantumRandomNumberGenerator

This project uses a QuantumCSharp library. This library is available here: https://github.com/spisiak/QuantumCSharp

Example:
 ```csharp
 
using QuantumCSharp;
using QuantumCSharp.HistoryResult;
using QuantumCSharp.Ibm;
using QuantumRandomNumbers;
using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HistoryResult program = new HistoryResult(new QuantumProgramOption()
            {
                Email = "", // put your email
                Password = "", // put your password
                Device = IbmQXDevices.ibmqx5,
                MaxCredits = 15,
                
            });

            QuantumRandomNumberGenerator qrng = new QuantumRandomNumberGenerator();
            var random_number = qrng.GenerateNumber(program, "ee1f326ebe08797c1363e3e00a537b6e");

            if (random_number != null)
            {
                Console.WriteLine("Random number:" + random_number.ToString());
            }

            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();

        }
    }
}

 
```
