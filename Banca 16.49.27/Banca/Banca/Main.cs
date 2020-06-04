using System;
using System.Net.Http.Headers;
using System.Reflection.Emit;

namespace Banca
{
    class Program
    {
        static void Main(string[] args)
        {


            var BCC = new Banca("BCC", "Via N.Bixio");
            int scelta = 0;

            do
            {
                Console.WriteLine("Scegli un'opzione:");
                Console.WriteLine("1 -Crea un nuovo contro corrente");
                Console.WriteLine("2 -Visualizza il tuo conto corrente");
                Console.WriteLine("3 -Elimina il tuo conto corrente");
                Console.WriteLine("4 -Effettua un versamento o un prelievo");
                Console.WriteLine("5 -Non ti ricordi il tuo codice iban?");
                Console.WriteLine("   Consulta una lista di tutti gli iban registrati");
                Console.WriteLine("");
                Console.WriteLine("6 -Esci");
                Console.WriteLine("");
                scelta = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("");

                switch (scelta)
                {
                    case 1:
                        {
                            string scelta1 = "";
                            double versamento = 0.0;
                            string nome = "";
                            string indirizzo = "";
                            string email = "";

                            Console.WriteLine("Inserisci il nome completo dell'intestatario:");
                            nome = Console.ReadLine();
                            Console.WriteLine("");

                            Console.WriteLine("Inserisci l'indirizzo di residenza:");
                            indirizzo = Console.ReadLine();
                            Console.WriteLine("");

                            Console.WriteLine("Inserisci un indirizzo email valido:");
                            email = Console.ReadLine();
                            Console.WriteLine("");

                            Console.WriteLine("Immetti la cifra del primo versamento:");
                            versamento = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("");

                            var cc1 = BCC.Add(new ContoCorrente(versamento, 0, 50));
                            cc1.SetIntestatario(new Intestatario(nome, DateTime.Now, indirizzo, email));

                            Console.WriteLine("Saldo attuale: " + cc1.Saldo() + ".");
                            Console.WriteLine("");

                            Console.WriteLine("Il tuo iban è: " + cc1.iban);
                            Console.WriteLine("");


                            do
                            {

                                Console.WriteLine("Vuoi effettuale un prelievo(A) o un versamento(B) ?");
                                Console.WriteLine("Se vuoi uscire digita C:");
                                scelta1 = Console.ReadLine().ToLower();
                                Console.WriteLine("");

                                switch (scelta1)
                                {
                                    case "a":
                                        {
                                            double cifra = 0;
                                            Console.WriteLine("Immetti la cifra del prelievo che vuoi effettuare:");
                                            cifra = Convert.ToDouble(Console.ReadLine());
                                            Console.WriteLine("");
                                            cc1.Prelievo(cifra);
                                            Console.WriteLine("Saldo attuale: " + cc1.Saldo() + ".");
                                            Console.WriteLine("");
                                        }
                                        break;

                                    case "b":
                                        {
                                            double cifra = 0;
                                            Console.WriteLine("Immetti la cifra del versamento che vuoi effettuare:");
                                            cifra = Convert.ToDouble(Console.ReadLine());
                                            Console.WriteLine("");
                                            cc1.Versamento(cifra);
                                            Console.WriteLine("Saldo attuale: " + cc1.Saldo() + ".");
                                            Console.WriteLine("");
                                        }
                                        break;

                                    case "c": break;

                                    default:
                                        Console.WriteLine("Inserisci una scelta valida.");
                                        Console.WriteLine(""); break;

                                }
                            } while (scelta1 != "c");
                            Console.Clear();

                            break;

                        }

                    case 2:
                        {
                            string iban = "";

                            Console.WriteLine("Immetti il tuo codice iban:");
                            iban = Console.ReadLine();

                            Console.WriteLine("Il conto corrente è intestato a:");
                            Console.WriteLine(BCC.GetContocorrente(iban).GetIntestatario().GetNome());
                            Console.WriteLine("");
                            Console.WriteLine("Il saldo attuale è di: " + BCC.GetContocorrente(iban).Saldo());
                            Console.WriteLine("");
                        }
                        Console.Clear();
                        break;

                    case 3:
                        {
                            string iban = "";
                            string conferma = "";

                            Console.WriteLine("Immeti il tuo codice iban:");
                            iban = Console.ReadLine();
                            Console.WriteLine("");

                            Console.WriteLine("Sei sicuro di volere eliminare il tuo conto corrente?");
                            Console.WriteLine("SI/NO");
                            conferma = Console.ReadLine().ToLower();
                            Console.WriteLine("");

                            if (conferma == "si")
                            {
                                if (BCC.Remove(iban) == true)
                                {
                                    Console.WriteLine("Il tuo conto corrente è stato eliminato");
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    Console.WriteLine("Si è verificato un errore,");
                                    Console.WriteLine("controlla che il codice iban sia corretto e riprova");
                                    Console.WriteLine("");
                                }
                            }



                        }
                        Console.Clear();
                        break;

                    case 4:
                        {
                            string scelta2 = "";
                            do
                            {
                                string iban = "";
                                double somma = 0;

                                Console.WriteLine("Vuoi effettuare un versamento(A) o un prelievo(B) ?");
                                Console.WriteLine("Se vuoi uscire digita C:");
                                scelta2 = Console.ReadLine().ToLower();
                                Console.WriteLine("");

                                if (scelta2 == "c")
                                { }
                                else
                                {
                                    Console.WriteLine("Immetti il tuo codice iban:");
                                    iban = Console.ReadLine();
                                    Console.WriteLine("");
                                }


                                switch (scelta2)
                                {
                                    case "a":
                                        {
                                            Console.WriteLine("Inserisci la somma da versare:");
                                            somma = Convert.ToDouble(Console.ReadLine());
                                            Console.WriteLine("");
                                            BCC.GetContocorrente(iban).Versamento(somma);

                                            Console.WriteLine("Il saldo attuale è di: " + BCC.GetContocorrente(iban).Saldo());
                                            Console.WriteLine("");
                                        }
                                        break;

                                    case "b":
                                        {
                                            Console.WriteLine("Inserisci la somma da prelevare:");
                                            somma = Convert.ToDouble(Console.ReadLine());
                                            Console.WriteLine("");
                                            BCC.GetContocorrente(iban).Prelievo(somma);

                                            Console.WriteLine("Il saldo attuale è di: " + BCC.GetContocorrente(iban).Saldo());
                                            Console.WriteLine("");
                                        }
                                        break;

                                    case "c": break;

                                    default:
                                        Console.WriteLine("Inserisci una scelta valida.");
                                        Console.WriteLine(""); break;
                                }
                            } while (scelta2 != "c");
                        }
                        Console.Clear();
                        break;

                    case 5:
                        {
                            string scelta3 = "";
                            foreach (ContoCorrente conto in BCC.elencoContiCorrenti)
                            {
                                Console.WriteLine("Il cliente a cui è associato il seguente codice iban è: " + conto.GetIntestatario().GetNome());
                                Console.WriteLine(conto.iban);
                                Console.WriteLine("");
                            }

                            do
                            {
                                Console.WriteLine("Per continuare scriva SI");
                                scelta3 = Console.ReadLine().ToLower();

                            } while (scelta3 != "si");
                            Console.Clear();
                        }
                        break;

                    case 6: Console.Clear(); break;
                }
            }
            while (scelta != 6);






        }
    }
}
