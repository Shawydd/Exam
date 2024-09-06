using Exam.Config;
using Exam.DAL;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Utils
{
    internal class FileIO
    {
        private static readonly string[] header = ["Aeroporto di Partenza",
            "Aeroporto di Destinazione", "Data", "Codice di Volo",
            "Gate", "Terminal", "Stato"];

        public static void FilteredCsv()
        {
            string statec = States.StateChecker();

            try
            {
                using (StreamWriter writer = new(FilePath.filteredFilePath))
                {
                    writer.WriteLine(string.Join(",", header));

                    foreach (var volo in VoloDAL.Instance().VoliList)
                        if (statec.Equals(volo.Stato))
                            writer.WriteLine(string.Join(",", volo.ToCsv()));
                }

                PrintMania.CsvCreato();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void PortableDB()
        {
            try
            {
                using StreamWriter writer = new(FilePath.dbFilePath);
                writer.WriteLine(string.Join(",", header));

                foreach (var volo in VoloDAL.Instance().VoliList)
                    writer.WriteLine(string.Join(",", volo.ToCsv()));

                PrintMania.CsvCreato();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ReadingMode()
        {
            byte count = 0;
            try
            {
                using StreamReader reader = new(FilePath.dbFilePath);
                // Skippiamo l'header
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var items = reader.ReadLine().Split(',');

                    Volo volo = new()
                    {
                        AeroportoPartenza = items[0],
                        AeroportoDestinazione = items[1],
                        Date = DateTime.Parse(items[2]),
                        CodiceVolo = items[3],
                        Gate = items[4],
                        Terminal = items[5],
                        Stato = items[6],
                    };

                    VoloDAL.Instance().VoliList.Add(volo);
                    count++;
                }

                Console.WriteLine($"{count} elementi sono stati" +
                    $" aggiunti alla nostra lista.");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
