using System;
using System.Collections.Generic;
using System.Text;

namespace Banca
{
    public class Banca
    {
        private string nome { get; } // nome della banca
        private string indirizzo { get; } // indirizzo della banca
        private string prossimoIban = ""; //prossimo iban
        private string iban = ""; //iban generato casualmente



        /// <summary>
        /// lista di conti correnti della banca
        /// </summary>
        public List<ContoCorrente> elencoContiCorrenti = new List<ContoCorrente>();

        /// <summary>
        /// costruttore
        /// </summary>
        /// <param name="nome_"></param>
        /// <param name="indirizzo_"></param>
        public Banca(string nome_, string indirizzo_)
        {
            nome = nome_;
            indirizzo = indirizzo_;

        }

        /// <summary>
        /// genera un iban casuale
        /// </summary>
        /// <param name="iban"></param>
        /// <returns></returns>
        public string GeneraIban(string iban)
        {
            for (int i = 0; i < 27; i++) 
            {
                Random rnd = new Random();
                int N = rnd.Next(0, 9);
                iban += Convert.ToString(N);

            }

            return iban;
        }



        /// <summary>
        /// aggiunge un conto corrente nella banca, assegnando il numero di conto corrente valido
        /// </summary>
        /// <param name="item"></param>
        /// <returns>ritorna il conto corrente con il numero di conto corrente aggiornato</returns>
        public ContoCorrente Add(ContoCorrente item)
        {
            // assegno alla variabile 'prossimoIban' un iban generato casualmente
            prossimoIban = (GeneraIban(iban));

            // assegno il numero del conto corrente a nuovo conto corrente
            item.iban = prossimoIban.ToString();
           
            elencoContiCorrenti.Add(item);
            return item;
        }

        /// <summary>
        /// funzione per rimuovere un conto corrente dalla banca
        /// </summary>
        /// <param name="iban_"></param>
        /// <returns>torna true se è stato cancellato oppure false</returns>
        public bool Remove(string iban_)
        {
            foreach (var item in elencoContiCorrenti)
            {
                if (item.iban == iban_)
                {
                    elencoContiCorrenti.Remove(item);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// funzione per prendere un conto corrente esistente dalla banca
        /// </summary>
        /// <param name="iban_"></param>
        /// <returns>torna il conto corrente se esiste oppure null</returns>
        public ContoCorrente GetContocorrente(string iban_)
        {
            foreach (var item in elencoContiCorrenti)
            {
                if (item.iban == iban_)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// restituisce l'elenco dei conti correnti della banca
        /// </summary>
        /// <returns>elenco conti correnti</returns>
        public List<ContoCorrente> ListaContocorrenti()
        {
            return elencoContiCorrenti;
        }

        /// <summary>
        /// permette di effettuare il bonifico su due conti correnti
        /// </summary>
        /// <param name="mandante_"></param>
        /// <param name="ricevente_"></param>
        /// <param name="importo_"></param>
        //public void Bonifico(string mandante_, string ricevente_, double importo_)
        //{
        //    var ccMandante = Get(mandante_);
        //    var ccRicevente = Get(ricevente_);
        //
            // controllo che sia il mandante che il ricevente siano esistenti e validi
        //    if (ccMandante != null && ccRicevente != null)
        //    {
        //        ccMandante.Prelievo(importo_);
        //        ccRicevente.Versamento(importo_);
        //        var bonifico = new Bonifico(DateTime.Now, mandante_, ricevente_, importo_);
        //        ccMandante.Add(bonifico);
        //        ccRicevente.Add(bonifico);
            }
        }
    
