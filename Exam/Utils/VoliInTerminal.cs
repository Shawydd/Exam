using Exam.DAL;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Utils
{
    internal class VoliInTerminal
    {
        public static void VoliInTerminalView()
        {
            Console.Write("Verranno mostrati solo voli in stato di \"IMBARCO IN CORSO\" o \"IN PARTENZA\", se presenti." +
                "\nInserisci un terminal da ricercare: ");
            string? idRTerm = Console.ReadLine();

            byte count = 0;

            foreach (Volo volo in VoloDAL.Instance().VoliList)
                if (idRTerm.Equals(volo.Terminal)
                    && (volo.Stato.Equals("IMBARCO IN CORSO")
                    || volo.Stato.Equals("IN PARTENZA")))
                {
                    count++;
                    Console.WriteLine(volo.ToString());
                }

            if (ValueCheck.DifferFromZeroCheck(count))
                Console.WriteLine($"Vi sono {count} voli nel terminal {idRTerm}.");
            else
                PrintMania.Nothingness();
        }
    }
}
