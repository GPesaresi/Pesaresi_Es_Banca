using System;
using System.Collections.Generic;
using System.Text;

namespace Banca
{
    public class Movimento
    {
        protected DateTime data; // data di quando è stato fatto il movimento

        /// <summary>
        /// costruttore
        /// </summary>
        /// <param name="data_"></param>
        public Movimento(DateTime data_)
        {
            data = data_;
        }
    }
}
