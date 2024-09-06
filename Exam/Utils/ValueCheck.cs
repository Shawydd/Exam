using Exam.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Utils
{
    internal class ValueCheck
    {
        public static bool BoolCheck()
        {
            char value;

            while (true)
            {
                value = StringCheck();

                if (value == '1' || value == '2')
                    return value == '1';

                PrintMania.ValoreNonConsono();
            }
        }

        private static int DateAndHourValidation(short max, byte realLength, short min)
        {
            int toValidate;
            while (true)
            {
                toValidate = NotNegativeIntegerChecker(realLength);
                if (min <= toValidate && toValidate <= max)
                    return toValidate;

                PrintMania.ValoreNonConsono();
            }
        }

        public static DateTime DateChecker()
        {
            const byte realYear = 4, realDateAndHours = 2;
            Console.Write($"\nInserire {Colors.CYAN}1{Colors.NORMAL}" +
                " per inserire data ed ora corrente, " +
                $"{Colors.CYAN}2{Colors.NORMAL} se si vuole passare " +
                "alla modalità personalizzata: ");

            if (BoolCheck())
                return DateTime.Now;

            Console.Write("Inserire l'anno: ");
            const short maxYear = 9999;
            const short minYear = 2000;
            int year;
            year = DateAndHourValidation(maxYear, realYear, minYear);

            Console.Write("Inserire il mese: ");
            const byte maxMonths = 12, minMonths = 1;
            int month;
            month = DateAndHourValidation(maxMonths, realDateAndHours, minMonths);

            Console.Write("Inserire il giorno: ");
            const byte maxDays = 31, minDays = minMonths;
            int day;
            day = DateAndHourValidation(maxDays, realDateAndHours, minDays);

            Console.Write("Inserire l'ora: ");
            const byte maxHours = 24, minHours = 0;
            int hour;
            hour = DateAndHourValidation(maxHours, realDateAndHours, minHours);

            if (hour == maxHours)
                hour = 0;

            Console.Write("Inserire i minuti: ");
            const byte maxMinutes = 60, minMinutes = minHours;
            int mins;
            mins = DateAndHourValidation(maxMinutes, realDateAndHours, minMinutes);

            if (mins == maxMinutes)
                mins = 0;

            return new DateTime(year, month, day, hour, mins, 0);
        }

        public static bool DifferFromZeroCheck(int value) => value != 0;

        private static int NotNegativeIntegerChecker(byte length)
        {
            int input;
            string? inpy;
            while (true)
            {
                try
                {
                    inpy = Console.ReadLine();
                    input = Int32.Parse(inpy);
                    if (inpy.Length <= length)
                        return input;

                    PrintMania.ValoreNonConsono();
                }
                catch
                {
                    PrintMania.ValoreNonConsono();
                }
            }
        }

        public static string NullChecker()
        {
            string? input;
            while (true)
            {
                input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input))
                    return input;

                PrintMania.ValoreNonConsono();
            }
        }

        public static string NullCheckerModificato()
        {
            PrintMania.Modifica();
            string? input;
            while (true)
            {
                input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input))
                {
                    PrintMania.ModificaAvvenuta();
                    return input;
                }

                PrintMania.ValoreNonConsono();
            }
        }

        public static char StringCheck()
        {
            const byte charCapacity = 1;
            string? choice;

            while (true)
            {
                choice = Console.ReadLine();

                PrintMania.Sbarrette();

                return choice is null || choice.Length is not charCapacity
                    ? 'X' : char.Parse(choice.ToUpper());
            }
        }
    }
}
