using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace B_U1_W1_D5_Progetto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contribuente.MostraAzioniSportello();
        }

        public class Contribuente
        {
            private static List<Utente> listUtents = new List<Utente>();

            public static void MostraAzioniSportello() {
                try
                {
                    Console.WriteLine("=========== OPERAZIONI =============");
                    Console.WriteLine("Scegli l'operazione da effettuare");
                    Console.WriteLine("1. Avviare il processo di inserimento dati per il calcolo dell'imposta sul reddito");
                    Console.WriteLine("2. Storico Contribuenti");
                    Console.WriteLine("3. Esci");
                    Console.WriteLine("====================================\n");

                    int scelta = int.Parse(Console.ReadLine());

                    if(scelta <= 0 || scelta > 3 ) {
                        Console.WriteLine("Hai inserito una scelta non esistente.\n");
                        Contribuente.MostraAzioniSportello();
                    }

                    switch (scelta)
                    {
                        case 1:
                            Contribuente.getDatiContribuente();
                            break;
                        case 2:
                            StoricoContribuenti();
                            break;
                        case 3:
                            Console.WriteLine("\nFine Operazioni");                           
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
       
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n{ex.Message}");
                    MostraAzioniSportello();
                }
            }

            public static void getDatiContribuente() {

                Utente utente = new Utente();

                utente.dataNascita = new DataNascita();

                Console.WriteLine("Inizio Processo");
                Console.WriteLine("\nInserire il suo nome e cognome in questo ordine:");
 
                Console.WriteLine("\nNome");
                utente.Nome = Console.ReadLine();


                Console.WriteLine("\nCognome");
                utente.Cognome = Console.ReadLine();


                Console.WriteLine("\nData di nascita");
                Console.WriteLine("Inserire il giorno");
                utente.dataNascita.Giorno = Console.ReadLine();
                Console.WriteLine("Inserire il mese");
                utente.dataNascita.Mese = Console.ReadLine();
                Console.WriteLine("Inserire l'anno");
                utente.dataNascita.Anno = Console.ReadLine();


                Console.WriteLine("\nCodice Fiscale");
                utente.CodiceFiscale = Console.ReadLine();


                Console.WriteLine("\nSesso");
                utente.Sesso = Console.ReadLine();


                Console.WriteLine("\nComune di Residenza");
                utente.ComuneResidenza = Console.ReadLine();


                Console.WriteLine("\nReddito Annuale");
                utente.RedditoAnnuale = int.Parse(Console.ReadLine());


                listUtents.Add(utente);
                Contribuente.CalcoloImpostaReddito();
            }
            public static void CalcoloImpostaReddito() {
                int ultimoUtente = listUtents.Count - 1;


                if (listUtents[ultimoUtente].RedditoAnnuale > 0 && listUtents[ultimoUtente].RedditoAnnuale <= 15000)
                {
                    listUtents[ultimoUtente].ImpostaDaVersare = (listUtents[ultimoUtente].RedditoAnnuale * 23) / 100;

                } else if (listUtents[ultimoUtente].RedditoAnnuale > 15001 && listUtents[ultimoUtente].RedditoAnnuale <= 28000) {

                    listUtents[ultimoUtente].ImpostaDaVersare = (((listUtents[ultimoUtente].RedditoAnnuale - 15000) * 27) / 100) + 3450;

                } else if (listUtents[ultimoUtente].RedditoAnnuale > 28001 && listUtents[ultimoUtente].RedditoAnnuale <= 55000) {

                    listUtents[ultimoUtente].ImpostaDaVersare = (((listUtents[ultimoUtente].RedditoAnnuale - 28000) * 38) / 100) + 6960;

                } else if (listUtents[ultimoUtente].RedditoAnnuale > 55001 && listUtents[ultimoUtente].RedditoAnnuale <= 75000)
                {

                    listUtents[ultimoUtente].ImpostaDaVersare = (((listUtents[ultimoUtente].RedditoAnnuale - 55000) * 41) / 100) + 17220;

                } else if (listUtents[ultimoUtente].RedditoAnnuale > 75001)
                {

                    listUtents[ultimoUtente].ImpostaDaVersare = (((listUtents[ultimoUtente].RedditoAnnuale - 75000) * 43) / 100) + 25420;

                }
                Contribuente.MostraRisultatiContribuente();
            }

            public static void MostraRisultatiContribuente() {

                try
                {
                    int ultimoUtente = listUtents.Count - 1;

                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    Console.WriteLine("======================================");
                    Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE \n\n");
                    Console.WriteLine($"Contribuente: {listUtents[ultimoUtente].Nome} {listUtents[ultimoUtente].Cognome}");
                    Console.WriteLine($"Nato il {listUtents[ultimoUtente].dataNascita.Giorno}/{listUtents[ultimoUtente].dataNascita.Mese}/{listUtents[ultimoUtente].dataNascita.Anno}");
                    Console.WriteLine($"Residente in {listUtents[ultimoUtente].ComuneResidenza}");
                    Console.WriteLine($"Codice Fiscale: {listUtents[ultimoUtente].CodiceFiscale} \n\n");
                    Console.WriteLine($"Reddito dichiarato: {listUtents[ultimoUtente].RedditoAnnuale} \n\n");
                    Console.WriteLine($"Importo da versare: {listUtents[ultimoUtente].ImpostaDaVersare:C}");
                    Console.WriteLine("====================================\n");
                    
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                } finally
                {
                    Contribuente.MostraAzioniSportello();
                }

            }

            public static void StoricoContribuenti()
            {
                try
                {
                    foreach (Utente item in listUtents)
                    {
                        Console.OutputEncoding = System.Text.Encoding.UTF8;
                        Console.WriteLine("======================================");
                        Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE \n\n");
                        Console.WriteLine($"Contribuente: {item.Nome} {item.Cognome}");
                        Console.WriteLine($"Nato il {item.dataNascita.Giorno}/{item.dataNascita.Mese}/{item.dataNascita.Anno}");
                        Console.WriteLine($"Residente in {item.ComuneResidenza}");
                        Console.WriteLine($"Codice Fiscale: {item.CodiceFiscale} \n\n");
                        Console.WriteLine($"Reddito dichiarato: {item.RedditoAnnuale} \n\n");
                        Console.WriteLine($"Importo da versare: {item.ImpostaDaVersare:C}");
                        Console.WriteLine("====================================\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                } finally {
                    Thread.Sleep(2000);
                    Contribuente.MostraAzioniSportello();
                }

            }
        }

        public class Utente
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public DataNascita dataNascita;
            public string CodiceFiscale { get; set; }
            public string Sesso { get; set; }
            public string ComuneResidenza { get; set; }
            public double RedditoAnnuale { get; set; }
            public double ImpostaDaVersare { get; set; }
        }

        public class DataNascita
        {
            public string Giorno { get; set; }
            public string Mese { get; set; }
            public string Anno { get; set; }
        }
    }

}
