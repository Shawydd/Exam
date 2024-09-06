using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DAL
{
    internal class DestinaCountDAL
    {
        public List<DestinaCount> DestCount = [];

        private static DestinaCountDAL? instance;

        public static DestinaCountDAL Instance()
        {
            instance ??= new DestinaCountDAL();

            return instance;
        }

        public static void DestCresc()
        {
            DestinaCountDAL.Instance().DestCount.Clear();

            foreach (Volo volo in VoloDAL.Instance().VoliList)
            {
                if (DestinaCountDAL.Instance().DestCount.Count == 0)
                {
                    DestinaCount input = new()
                    {
                        Destinazione = volo.AeroportoDestinazione,
                        Counting = 1
                    };

                    DestinaCountDAL.Instance().DestCount.Add(input);
                }
                else
                {
                    bool truer = true;

                    foreach (DestinaCount dest in DestinaCountDAL.Instance().DestCount)
                        if (volo.AeroportoDestinazione.Equals(dest.Destinazione))
                        {
                            dest.Counting++;
                            truer = false;
                        }

                    if (truer)
                    {
                        DestinaCount inpy = new()
                        {
                            Destinazione = volo.AeroportoDestinazione,
                            Counting = 1
                        };

                        DestinaCountDAL.Instance().DestCount.Add(inpy);
                    }
                }
            }

            List<DestinaCount> SortedList = [.. DestinaCountDAL.Instance().DestCount.OrderBy(o => o.Counting)];

            foreach (DestinaCount dest in SortedList)
                Console.WriteLine(dest.ToString());
        }
    }


}
