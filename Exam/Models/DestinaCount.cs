using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    internal class DestinaCount
    {
        public string Destinazione { get; set; } = null!;

        public byte Counting { get; set; }

        public override string ToString() =>
            $"Voli per {Destinazione}: {Counting}";

    }
}
