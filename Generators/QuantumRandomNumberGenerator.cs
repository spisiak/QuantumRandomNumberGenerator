using QuantumCSharp;
using QuantumCSharp.HistoryResult;
using QuantumCSharp.Ibm;
using System.Linq;

namespace QuantumRandomNumbers
{
    public class QuantumRandomNumberGenerator
    {
        public QuantumRandomNumber GenerateNumber(QuantumProgram program, int QubitNumber)
        {
            program.Clear();
            program.Options.Shots = 2048;
            Qubit[] qubits = new Qubit[QubitNumber];
            for(int i =0;i < QubitNumber;i++)
            {
                qubits[i] = new Qubit(program, i);
                qubits[i].H();
            }
            var quantum_number =  new QuantumRandomNumber() { IbmResult = program.Execute() };
            if (quantum_number.IbmResult.State == IbmQXSendState.Ok)
            {
                var tmp = program.GetQubitResultStates(quantum_number.IbmResult);
                tmp = (from t in tmp orderby t.Index ascending select t).ToList();
                short[] quantum_values = new short[QubitNumber];
                for(int i = 0;i < QubitNumber;i++)
                {
                    quantum_values[i] = (short)(tmp[i].One % 100);
                }
                quantum_number.SetQuantumNumber(quantum_values);
            }
            return null;
        }

        public QuantumRandomNumber GenerateNumber(HistoryResult program, string HistoryResultId)
        {
            var items = program.GetHistoryResults().Result;
            if (items.Count == 0)
                return null;
            var result = program.GetQubitResultStatesById(items, HistoryResultId);
            if (result != null)
            {
                var quantum_number = new QuantumRandomNumber();
                result = (from t in result orderby t.Index ascending select t).ToList();
                short[] quantum_values = new short[result.Count];
                for (int i = 0; i < result.Count; i++)
                {
                    quantum_values[i] = (short)(result[i].One % 100);
                }
                quantum_number.SetQuantumNumber(quantum_values);
                return quantum_number;
            }
            return null;
        }

    }
}
