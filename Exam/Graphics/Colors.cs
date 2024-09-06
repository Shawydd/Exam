using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Graphics
{
    internal class Colors
    {
        public static readonly string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
        public static readonly string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
    }
}
