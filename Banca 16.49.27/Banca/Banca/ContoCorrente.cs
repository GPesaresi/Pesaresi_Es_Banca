using System;
using System.Collections.Generic;
using System.Text;

namespace Banca
{
    public class ContoCorrente
    {
        protected double saldo = 0; // saldo del conto corrente
        protected int nMovimenti = 0; // numero di movimenti sul conto corrente
        protected int maxMovimenti = 50; // max movimenti sul conto corrente
        public string iban;
        protected Intestatario intestatario = null;

        protected List<Bonifico> elencoBonifici = new List<Bonifico>();

        /// <summary>
        /// costruttore
        /// </summary>
        /// <param name="saldo_"></param>
        /// <param name="nMovimenti_"></param>
        /// <param name="maxMovimenti_"></param>
        public ContoCorrente(double saldo_, int nMovimenti_, int maxMovimenti_)
        {
            saldo = saldo_;
            nMovimenti = nMovimenti_;
            maxMovimenti = maxMovimenti_;
        }

        /// <summary>
        /// funzione per archiviare un bonifico *
        /// </summary>
        /// <param name="bonifico_"></param>
        public virtual void Add(Bonifico bonifico_)
        {
            elencoBonifici.Add(bonifico_);
        }

        /// <summary>
        /// ritorna l'elenco dei bonifica archiviati*
        /// </summary>
        /// <returns></returns>
        public List<Bonifico> GetBonifici()
        {
            return elencoBonifici;
        }

        /// <summary>
        /// assegno l'intestaraio del conto corrente
        /// </summary>
        /// <param name="intestatario_"></param>
        public void SetIntestatario(Intestatario intestatario_)
        {
            intestatario = intestatario_;
        }

        /// <summary>
        /// restituisco l'intestatario del conto corrente
        /// </summary>
        /// <returns>intestatario</returns>
        public Intestatario GetIntestatario()
        {
            return intestatario;
        }

        /// <summary>
        /// prelievo di una somma dal conto corrente
        /// </summary>
        /// <param name="sommaDaPrelevare"></param>
        /// <returns>somma prelevata</returns>
        public virtual double Prelievo(double sommaDaPrelevare)
        {
            saldo -= sommaDaPrelevare;
            nMovimenti++;

            if (nMovimenti > maxMovimenti)
            {
                saldo -= 0.50;
            }
            return sommaDaPrelevare;
        }

        /// <summary>
        /// versamento di una somma nel conto corrente
        /// </summary>
        /// <param name="sommaDaVersare"></param>
        /// <returns>somma versata</returns>
        public double Versamento(double sommaDaVersare)
        {
            saldo += sommaDaVersare;
            nMovimenti++;

            if (nMovimenti > maxMovimenti)
            {
                saldo -= 0.50;
            }
            return sommaDaVersare;
        }

        /// <summary>
        /// saldo
        /// </summary>
        /// <returns>saldo</returns>
        public double Saldo()
        {
            return saldo;
        }
    }
}
