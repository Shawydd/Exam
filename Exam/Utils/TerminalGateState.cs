using Exam.DAL;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Utils
{
    internal class TerminalGateState
    {
        public static bool TerminalGateStateView()
        {
            Console.Write("Inserisci l'ID del volo di cui si vuole " +
                "conoscere il terminal, il gate e lo stato: ");
            string? idTermGateState = Console.ReadLine();

            foreach (Volo volo in VoloDAL.Instance().VoliList)
            {
                if (idTermGateState.Equals(volo.CodiceVolo))
                {
                    Console.WriteLine($"Terminal: {volo.Terminal}, " +
                        $"Gate: {volo.Gate}, Stato: {volo.Stato}");
                    return true;
                }
            }
            return false;
        }
    }
}
