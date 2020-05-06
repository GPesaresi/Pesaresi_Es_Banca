using System;
using System.Net.Http.Headers;

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
                Console.WriteLine("2 -Visualizza il tuo conto corrente ");
                Console.WriteLine("3 -Esci");
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
                        break;
                }
            }
            while (scelta != 3);





            // esempio
            //var banca = new Banca("Banca dei poveri", "Vicolo stretto"); // deve essere istanziata una sola banca
            //var cc0 = banca.Add(new ContoCorrente(1000, 0, 50)); // aggiungo un conto corrente
            //cc0.SetIntestatario(new Intestatario("Pietro Smusi", DateTime.Now, "Piazza della Vittoria", "pietrosmusi89@gmail.com")); // imposto intestatario ad un conto corrente
            //Console.WriteLine("Saldo corrente " + cc0.Saldo());
            //cc0.Versamento(100); // faccio un versamento
            //Console.WriteLine("Versamento di 100 euro... ");
            //cc0.Prelievo(1000); // prelievo
            //Console.WriteLine("Prelievo di 1000 euro... ");
            //var saldo = cc0.Saldo(); // saldo
            //Console.WriteLine("Saldo corrente " + saldo); // stampa il saldo rimanente


            // esempio successivo
            //var cc1 = banca.Add(new ContoCorrente(1000, 51, 50)); // aggiungo un conto corrente
            //cc1.SetIntestatario(new Intestatario("Pietro Smusi", DateTime.Now, "Piazza della Vittoria", "pietrosmusi89@gmail.com")); // imposto intestatario ad un conto corrente
            //Console.WriteLine("\nSaldo corrente " + cc1.Saldo());
            //cc1.Versamento(100); // faccio un versamento
            //Console.WriteLine("Versamento di 100 euro... ");
            //cc1.Prelievo(1000); // prelievo
            //Console.WriteLine("Prelievo di 1000 euro... ");
            //Double saldo1 = cc1.Saldo(); // saldo
            // Console.WriteLine("Saldo corrente " + saldo1); // stampa il saldo rimanente



            // situazione prima del bonifico 
            //Console.WriteLine("Saldo conto corrente mittente " + cc0.Saldo().ToString());
            //Console.WriteLine("Saldo conto corrente destinatario " + cc1.Saldo().ToString());
            //Console.WriteLine("\nBonifico di 50 euro in corso...\n");
            //banca.Bonifico(cc0.iban, cc1.iban, 50); // esempio di un bonifico tra due conti correnti
            // situazione dopo il bonifico
            //Console.WriteLine("Saldo conto corrente mittente " + cc0.Saldo().ToString());
            //Console.WriteLine("Saldo conto corrente destinario " + cc1.Saldo().ToString());
            //Console.ReadKey();
        }
    }
}
