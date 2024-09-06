using Exam.DAL;
using Exam.Graphics;
using Exam.Models;
using Exam.Utils;
using System.ComponentModel.Design;
using System.Data;
using System.Xml.Serialization;

namespace Exam
{
    internal class Program
    {
        static void Main()
        {
            /*
            Task di gestione dati .NET

            Sviluppare un sistema di gestione dati interattivo, permette all'utente di interfacciarsi con il sistema ed effettuare delle operazioni CRUD di voti degli aeroporti.
            Ogni volo è caratterizzato da:
            - Aeroporto di partenza, con nome e sigla;
            - Aeroporto di destinazione, con nome e sigla;
            - Data ed ora (se non sapete come fare, semplice stringa);
            - Codice del volo (string);
            - Gate (string);
            - Terminal (string) (all'interno del terminal ci sono vari gate);
            - Stato, in arrivo, imbarco in corso, in partenza, in ritardo, cancellato.
             
             Prevedere i seguenti metodi specifici:
            - Dato il codice di volo, conoscere il Terminal, Gate e Stato;
            - Dato il codice di volo, cambiare lo stato in uno dei selezionati;
            - Numero di voli presenti in un terminal (in stato di imbarco in corso, in partenza);
            - Elenco delle destinazioni in ordine cresente per numero di voli;
            - Esporta in CSV tutti i voli in un certo stato (stato specifico unico, o in arrivo, o in imbarco o in partenza etc.)
             */

            Console.WriteLine("Benvenuto/a!");

            while (true)
            {

                PrintMania.Sbarrette();

                PrintMania.Menu();

                switch (ValueCheck.StringCheck())
                {
                    case 'C':
                        //Metodo per creazione nuovo volo;
                        Console.WriteLine(VoloDAL.Instance().Insert()
                            ? "Elemento aggiunto con successo!"
                            : "Qualcosa è andato storto...");
                        break;
                    case 'R':
                        //Metodo per la lettura di un volo (o anche tutti);
                        if (!ValueCheck.DifferFromZeroCheck(VoloDAL.Instance().VoliList.Count))
                            PrintMania.Nothingness();
                        else
                        {
                            Console.Write("Vuoi visualizzare un volo specifico o tutti?" +
                                $" Inserisci {Colors.CYAN}1{Colors.NORMAL} per tutti, {Colors.CYAN}2{Colors.NORMAL} per uno specifico: ");

                            if (ValueCheck.BoolCheck())
                                VoloDAL.Instance().FindAll();
                            else
                            {
                                Console.Write("Inserisci l'ID di un volo da cercare: ");
                                string? idRicerca = Console.ReadLine();
                                VoloDAL.Instance().FindById(idRicerca);
                            }
                        }
                        break;
                    case 'U':
                        //Metodo per l'update di un volo;
                        if (!ValueCheck.DifferFromZeroCheck(VoloDAL.Instance().VoliList.Count))
                            PrintMania.Nothingness();
                        else
                        {
                            Console.Write("Inserisci l'ID di un volo da modificare: ");
                            string? idRicerca = Console.ReadLine();

                            VoloDAL.Instance().Update(idRicerca);
                        }
                        break;
                    case 'D':
                        //Metodo per la cancellazione di un volo;
                        if (!ValueCheck.DifferFromZeroCheck(VoloDAL.Instance().VoliList.Count))
                            PrintMania.Nothingness();
                        else
                        {
                            Console.Write("Inserisci l'ID di un volo da cancellare: ");
                            string? idRicerca = Console.ReadLine();
                            if (!VoloDAL.Instance().DeleteById(idRicerca))
                                PrintMania.VoloNonTrovato();
                            else
                                PrintMania.ModificaAvvenuta();
                        }
                        break;
                    case '1':
                        //Dato il codice di volo, ridare terminal, gate e stato
                        if (!TerminalGateState.TerminalGateStateView())
                            PrintMania.VoloNonTrovato();
                        break;
                    case '2':
                        //Dato il codice di volo, cambiare lo stato di un volo
                        if (ModificaStatoVolo.ModificaStatoVoloView())
                            PrintMania.ModificaAvvenuta();
                        else
                            PrintMania.VoloNonTrovato();
                        break;
                    case '3':
                        //Numero di voli presenti in un terminal specifico (in stato di imbarco in corso
                        //ed in partenza)
                        VoliInTerminal.VoliInTerminalView();
                        break;
                    case '4':
                        //Elenco delle destinazioni in ordine crescente per numero di voli
                        //Nel dubbio vengono considerati anche i voli CANCELLATI
                        if (!ValueCheck.DifferFromZeroCheck(VoloDAL.Instance().VoliList.Count))
                            PrintMania.Nothingness();
                        else
                            DestinaCountDAL.DestCresc();
                        break;
                    case '5':
                        //Esportazione CSV dei voli in uno stato specifico
                        FileIO.FilteredCsv();
                        break;
                    case 'L':
                        //Lettura da file csv su percorso specifico
                        FileIO.ReadingMode();
                        break;
                    case 'S':
                        //Lettura da file csv su percorso specifico
                        FileIO.PortableDB();
                        break;
                    case 'Q':
                        //ByeBye
                        Console.WriteLine("Buona giornata!");
                        return;
                    default:
                        Console.WriteLine("Input non valido, ritenta.");
                        break;
                }
            }
        }
    }
}
