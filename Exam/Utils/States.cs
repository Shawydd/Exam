using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Utils
{
    internal class States
    {
        private static readonly string[] states = ["IN ARRIVO", "IMBARCO IN CORSO",
            "IN PARTENZA", "IN RITARDO", "CANCELLATO"];

        public static string StateChecker()
        {
            string? choice;

            Console.WriteLine("Selezionare il tipo di stato volo tra i seguenti: \n");

            foreach (string state in states)
                Console.WriteLine($"{state}");

            Console.Write("\nScelta: ");

            while (true)
            {
                choice = Console.ReadLine().ToUpper();

                foreach (string state in states)
                    if (choice.Equals(state))
                        return choice;

                PrintMania.ValoreNonConsono();
            }
        }
    }
}
