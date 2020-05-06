using System;
using System.Collections.Generic;
using System.Text;

namespace Banca
{
    public class Bonifico : Movimento
    {
        private string mandante; // chi manda
        private string ricevente; // chi riceve
        private double importo; // importo della transazione
        private bool online = false; // indica se il bonifico è stato fatto da un conto online

        /// <summary>
        /// costruttore
        /// </summary>
        /// <param name="data_"></param>
        /// <param name="mandante_"></param>
        /// <param name="ricevente_"></param>
        /// <param name="importo_"></param>
        public Bonifico(DateTime data_, string mandante_, string ricevente_, double importo_) :
            base(data_)
        {
            data = data_;
            mandante = mandante_;
            ricevente = ricevente_;
            importo = importo_;
        }

        /// <summary>
        /// imposta la variabile online a true per indicare che è il bonifico è stato fatto da un conto online
        /// </summary>
        public void SetOnline()
        {
            online = true;
        }
    }
}
