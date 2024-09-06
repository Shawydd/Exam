using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exam.Models
{
    internal class Volo
    {
        public string AeroportoPartenza { get; set; } = null!;

        public string AeroportoDestinazione { get; set; } = null!;

        public DateTime Date { get; set; }

        public string CodiceVolo { get; set; } = null!;

        public string Gate { get; set; } = null!;

        public string Terminal { get; set; } = null!;

        public string Stato { get; set; } = null!;

        public override string ToString() =>
             $"Partenza: {AeroportoPartenza}, Destinazione: {AeroportoDestinazione}, Data: " +
                Date.ToString("g") + $".\nCodice Volo: {CodiceVolo}, Gate: {Gate}, " +
                    $"Terminal: {Terminal}, Stato: {Stato}.\n";

        public string[] ToCsv() =>
            [AeroportoPartenza, AeroportoDestinazione, Date.ToString("g"),
                CodiceVolo, Gate, Terminal, Stato];
    }
}
