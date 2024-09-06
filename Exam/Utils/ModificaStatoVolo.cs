using Exam.DAL;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Utils
{
    internal class ModificaStatoVolo
    {
        public static bool ModificaStatoVoloView()
        {
            Console.Write("Inserisci l'ID per la modifica stato: ");
            string? idRVer = Console.ReadLine();

            foreach (Volo volo in VoloDAL.Instance().VoliList)
                if (idRVer.Equals(volo.CodiceVolo))
                {
                    volo.Stato = States.StateChecker();
                    return true;
                }
            return false;
        }
    }
}
