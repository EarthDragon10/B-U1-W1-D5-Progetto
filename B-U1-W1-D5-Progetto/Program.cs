using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_U1_W1_D5_Progetto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contribuente contribuente = new Contribuente();
            Contribuente.MostraAzioniSportello();
        }

        public class Contribuente
        {
            //private static List<Utente> listUtents = new List<Utente>();
            public static string Nome { get; set; }
            public static string Cognome { get; set; }
            public static string DataNascita { get; set; }

            public static string CodiceFiscale { get; set; }
            public static string Sesso { get; set; }
            public static string ComuneResidenza { get; set; }

            public static double RedditoAnnuale { get; set; }

            public static double ImportoDaVersare { get; set; }

            public static void MostraAzioniSportello() {
                try
                {
                    Console.WriteLine("=========== OPERAZIONI =============");
                    Console.WriteLine("Scegli l'operazione da effettuare");
                    Console.WriteLine("1. Avviare il processo di inserimento dati per il calcolo dell'imposta sul reddito");           
                    Console.WriteLine("2. Esci");
                    Console.WriteLine("====================================\n");

                    int scelta = int.Parse(Console.ReadLine());

                    switch (scelta)
                    {
                        case 1:
                            getDatiContribuente();
                            break;                   
                        case 2:
                            Console.WriteLine("\nFine Operazioni");
                            Console.ReadLine();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MostraAzioniSportello();
                }
            }

            public static void getDatiContribuente() {
              

                Console.WriteLine("Inizio Processo");
                Console.WriteLine("\nInserire il suo nome e cognome in questo ordine:");

                Console.WriteLine("\nNome");
                Contribuente.Nome = Console.ReadLine();

                Console.WriteLine("\nCognome");
                Contribuente.Cognome = Console.ReadLine();

                Console.WriteLine("\nData di nascita");
                Contribuente.DataNascita = Console.ReadLine();

                Console.WriteLine("\nCodice Fiscale");
                Contribuente.CodiceFiscale = Console.ReadLine();

                Console.WriteLine("\nSesso");
                Contribuente.Sesso = Console.ReadLine();

                Console.WriteLine("\nComune di Residenza");
                Contribuente.ComuneResidenza = Console.ReadLine();

                Console.WriteLine("\nReddito Annuale");
                Contribuente.RedditoAnnuale = int.Parse(Console.ReadLine());

                Contribuente.CalcoloImpostaReddito();
            }
            public static void CalcoloImpostaReddito() {


                if(Contribuente.RedditoAnnuale > 0 && Contribuente.RedditoAnnuale <= 15000)
                {
                    Contribuente.ImportoDaVersare = (Contribuente.RedditoAnnuale * 23) / 100;

                } else if(Contribuente.RedditoAnnuale > 15001 && Contribuente.RedditoAnnuale <= 28000) {

                    Contribuente.ImportoDaVersare = (((Contribuente.RedditoAnnuale - 15000) * 27) / 100) + 3450;

                } else if (Contribuente.RedditoAnnuale > 28001 && Contribuente.RedditoAnnuale <= 55000) {

                    Contribuente.ImportoDaVersare = (((Contribuente.RedditoAnnuale - 28000) * 38) / 100) + 6960;

                } else if (Contribuente.RedditoAnnuale > 55001 && Contribuente.RedditoAnnuale <= 75000)
                {

                    Contribuente.ImportoDaVersare = (((Contribuente.RedditoAnnuale - 55000) * 41) / 100) + 17220;

                } else if (Contribuente.RedditoAnnuale > 75001)
                {

                    Contribuente.ImportoDaVersare = (((Contribuente.RedditoAnnuale - 75000) * 43) / 100) + 25420;

                }
                Contribuente.MostraRisultatiContribuente();
            }

            public static void MostraRisultatiContribuente () {
                Console.WriteLine("======================================");
                Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE \n\n");
                Console.WriteLine($"Contribuente: {Contribuente.Nome} {Contribuente.Cognome}");
                Console.WriteLine($"Nato il {Contribuente.DataNascita}");
                Console.WriteLine($"Residente in {Contribuente.ComuneResidenza}");
                Console.WriteLine($"Codice Fiscale: {Contribuente.CodiceFiscale} \n\n");
                Console.WriteLine($"Reddito dichiarato: {Contribuente.RedditoAnnuale} \n\n");
                Console.WriteLine($"Importo da versare {Contribuente.ImportoDaVersare}");
                Console.WriteLine("====================================\n");
            }
        }

        public class Utente
        {
            public static string Nome { get; set; }
            public static string Cognome { get; set; }
            public static DataNascita dataNascita;
            public static string CodiceFiscale { get; set; }
            public static string Sesso { get; set; }
            public static string ComuneResidenza { get; set; }
            public static double RedditoAnnuale { get; set; }
            public static double ImpostaDaVersare { get; set; }
        }

        public class DataNascita
        {
            public string Giorno { get; set; }
            public string Mese { get; set; }
            public string Anno { get; set; }
        }
    }

}
