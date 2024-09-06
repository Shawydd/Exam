using Exam.Graphics;
using Exam.Models;
using Exam.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DAL
{
    internal class VoloDAL : IDAL<Volo>
    {
        public List<Volo> VoliList = [];

        //I metodi dall'1 al 5 dovrebbero andare nel controller, ma vengono messi qui.
        //Nelle classi vengono messe solo metodi del tipo toString, etc...

        private static VoloDAL? instance;

        public static VoloDAL Instance()
        {
            instance ??= new VoloDAL();

            return instance;
        }
        public bool DeleteById(string id)
        {
            foreach (Volo volo in VoliList)
                if (id.Equals(volo.CodiceVolo))
                {
                    Console.WriteLine("Volo trovato: " + volo.ToString());
                    Console.Write("Cancellare il volo trovato? " +
                        $"Inserire {Colors.CYAN}1{Colors.NORMAL} per Si, {Colors.CYAN}2{Colors.NORMAL} per No: ");

                    if (ValueCheck.BoolCheck())
                        VoliList.Remove(volo);
                    else
                        Console.WriteLine("Il volo non è stato eliminato.");

                    return true;
                }
            return false;
        }

        public void FindAll()
        {
            foreach (var volo in VoliList)
                Console.WriteLine(volo);
        }

        public void FindById(string id)
        {
            foreach (Volo volo in VoliList)
                if (id.Equals(volo.CodiceVolo))
                {
                    Console.WriteLine("Volo trovato: " + volo.ToString());
                    return;
                }

            PrintMania.VoloNonTrovato();
        }

        public bool Insert()
        {
            Console.Write("Inserisci l'aeroporto di partenza: ");
            string aeroPart = ValueCheck.NullChecker();

            Console.Write("Inserisci l'aeroporto di destinazione: ");
            string aeroDest = ValueCheck.NullChecker(); ;

            Console.Write("Inserisci la data: ");
            DateTime date = ValueCheck.DateChecker();

            /*Console.WriteLine(date.ToString("g"));*/

            Console.Write("Inserisci il codice del gate: ");
            string codGate = ValueCheck.NullChecker();

            Console.Write("Inserisci il codice del terminal: ");
            string codTerm = ValueCheck.NullChecker();

            string stato = States.StateChecker();

            Volo volo = new()
            {
                AeroportoPartenza = aeroPart,
                AeroportoDestinazione = aeroDest,
                Date = date,
                CodiceVolo = CodeGen.CodeEnvironmentTest(),
                Gate = codGate,
                Terminal = codTerm,
                Stato = stato
            };

            int lenghy = VoloDAL.Instance().VoliList.Count;
            VoliList.Add(volo);

            return lenghy < VoloDAL.Instance().VoliList.Count;
        }

        public void Update(string id)
        {
            foreach (Volo volo in VoliList)
                if (id.Equals(volo.CodiceVolo))
                {
                    Console.WriteLine("Volo trovato: " + volo.ToString());
                    Console.Write("Modificare il volo trovato? " +
                        $"Inserire {Colors.CYAN}1{Colors.NORMAL} per Si, {Colors.CYAN}2{Colors.NORMAL} per No: ");

                    if (ValueCheck.BoolCheck())
                    {
                        Console.Write("Inserire il seguente valore per modificare " +
                            "il corrispettivo campo:\n" +
                            $"{Colors.CYAN}1{Colors.NORMAL} - Aeroporto di Partenza\n" +
                            $"{Colors.CYAN}2{Colors.NORMAL} - Aeroporto di Destinazione\n" +
                            $"{Colors.CYAN}3{Colors.NORMAL} - Data\n" +
                            $"{Colors.CYAN}4{Colors.NORMAL} - Gate\n" +
                            $"{Colors.CYAN}5{Colors.NORMAL} - Terminal\n" +
                            $"{Colors.CYAN}6{Colors.NORMAL} - Stato\n" +
                            "Scelta: ");

                        switch (ValueCheck.StringCheck())
                        {
                            case '1':
                                volo.AeroportoPartenza = ValueCheck.NullCheckerModificato();
                                return;
                            case '2':
                                volo.AeroportoDestinazione = ValueCheck.NullCheckerModificato();
                                return;
                            case '3':
                                volo.Date = ValueCheck.DateChecker();
                                PrintMania.ModificaAvvenuta();
                                return;
                            case '4':
                                volo.Gate = ValueCheck.NullCheckerModificato();
                                return;
                            case '5':
                                volo.Terminal = ValueCheck.NullCheckerModificato();
                                return;
                            case '6':
                                volo.Stato = States.StateChecker();
                                PrintMania.ModificaAvvenuta();
                                return;
                            default:
                                Console.WriteLine("Valore inserito non valido. " +
                                    "Il processo verrà chiuso.");
                                return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nessuna modifica avvenuta.");
                        return;
                    }
                }
            PrintMania.VoloNonTrovato();
        }
    }
}
