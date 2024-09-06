using Exam.DAL;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Utils
{
    internal class CodeGen
    {
        private static bool CodeCompare(string code)
        {
            foreach (Volo volo in VoloDAL.Instance().VoliList)
                if (code.Equals(volo.CodiceVolo))
                    return true;

            return false;
        }

        public static string CodeEnvironmentTest()
        {
            if (!ValueCheck.DifferFromZeroCheck(VoloDAL.Instance().VoliList.Count))
                return CodeGenerator();

            bool condition = true;
            string code = "";

            while (condition)
            {
                code = CodeGenerator();
                condition = CodeCompare(code);
            }

            return code;
        }

        private static string CodeGenerator()
        {
            const byte codeLimit = 4;
            char[] chars = new char[codeLimit];

            var rand = new Random();

            // Generatore randomico codice
            for (byte i = 0; i < codeLimit; i++)
                chars[i] = rand.Next(2) is 0
                    ? Convert.ToChar(rand.Next(48, 58))
                    : Convert.ToChar(rand.Next(65, 91));

            return new string(chars);
        }
    }
}
