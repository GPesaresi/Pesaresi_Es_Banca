using System;
using System.Collections.Generic;
using System.Text;

namespace Banca
{
    public class ContoCorrenteOnline : ContoCorrente
    {
        private double maxPrelievo; // prelievo massimo dal conto corrente 

        /// <summary>
        /// costruttore
        /// </summary>
        /// <param name="maxPrelievo_"></param>
        /// <param name="saldo_"></param>
        /// <param name="nMovimenti_"></param>
        /// <param name="maxMovimenti_"></param>
        public ContoCorrenteOnline(double maxPrelievo_, double saldo_, int nMovimenti_, int maxMovimenti_) :
            base(saldo_, nMovimenti_, maxMovimenti_)
        {
            maxPrelievo = maxPrelievo_;
        }

        /// <summary>
        /// saldo del conto corrente
        /// </summary>
        /// <returns></returns>
        public double saldoContoCorrente()
        {
            return 0;
        }

        /// <summary>
        /// prelievo di una somma dal conto corrente con verifica di non superare l'importo massimo
        /// </summary>
        /// <param name="sommaDaPrelevare"></param>
        /// <returns></returns>
        public new double Prelievo(double sommaDaPrelevare)
        {
            if (sommaDaPrelevare > maxPrelievo)
            {
                return 0;
            }
            return Prelievo(sommaDaPrelevare);
        }

        /// <summary>
        /// permette di archiviare un bonifico nel conto corrente *
        /// </summary>
        /// <param name="bonifico_"></param>
        public override void Add(Bonifico bonifico_)
        {
            bonifico_.SetOnline();
            Add(bonifico_);
        }
    }
}
