using Exam.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Utils
{
    internal class PrintMania
    {
        public static void CsvCreato() => Console.WriteLine("File CSV creato con successo!");

        public static void Menu() => Console.Write($"Inserisci:\n   {Colors.CYAN}C{Colors.NORMAL} per inserire un nuovo volo,\n" +
        $"   {Colors.CYAN}R{Colors.NORMAL} per stampare l'elenco di tutti o di uno specifico volo,\n" +
        $"   {Colors.CYAN}U{Colors.NORMAL} per modificare un volo,\n" +
        $"   {Colors.CYAN}D{Colors.NORMAL} per cancellare un volo.\n\n" +
        "È possibile inoltre:\n" +
        $"   con {Colors.CYAN}1{Colors.NORMAL} conoscere il Terminal, Gate e Stato di un volo,\n" +
        $"   con {Colors.CYAN}2{Colors.NORMAL} cambiare lo stato di uno dei voli selezionati,\n" +
        $"   con {Colors.CYAN}3{Colors.NORMAL} conoscere il numero di voli presenti in un terminal,\n" +
        $"   con {Colors.CYAN}4{Colors.NORMAL} visualizzare l'elenco delle destinazioni in ordine crescente per numero di voli,\n" +
        $"   con {Colors.CYAN}5{Colors.NORMAL} esportare in CSV tutti i voli in uno stato specifico.\n\n" +
        "Funzioni speciali:\n" +
        $"   con {Colors.CYAN}L{Colors.NORMAL} si possono leggere gli elementi presenti da un determinato file CSV,\n" +
        $"   con {Colors.CYAN}S{Colors.NORMAL} si salvano tutti gli elementi presenti in memoria in un file CSV,\n" +
        $"   con {Colors.CYAN}Q{Colors.NORMAL} si esce.\n" +
        "La tua scelta: ");

        public static void Modifica() => Console.Write("Inserire la modifica: ");

        public static void ModificaAvvenuta() =>
            Console.WriteLine("Modifica avvenuta con successo!");

        public static void Nothingness() => Console.WriteLine("Non c'è nulla...");

        public static void Sbarrette() =>
            Console.Write("---------------------------------------------" +
                "---------------------------------------------\n");

        public static void ValoreNonConsono() =>
            Console.Write("Valore inserito non consono, riprovare: ");

        public static void VoloNonTrovato() => Console.WriteLine("Volo non trovato.");

    }
}
