using System;
using System.Collections.Generic;
using System.Text;

namespace Banca
{
    public class Intestatario
    {
        private string nomeCompleto;  // nome dell'intestatario
        private DateTime dataNascita; // data nascita dell'intestatario
        private string indirizzo; // indirizzo dell'intestatario 
        private string email; // e-mail dell'intestatario

        public string GetNome()
        {
            return nomeCompleto;
        }

        /// <summary>
        /// costruttore
        /// </summary>
        /// <param name="nomeCompleto_"></param>
        /// <param name="dataNascita_"></param>
        /// <param name="indirizzo_"></param>
        /// <param name="email_"></param>
        public Intestatario(string nomeCompleto_, DateTime dataNascita_, string indirizzo_, string email_)
        {
            nomeCompleto = nomeCompleto_;
            dataNascita = dataNascita_;
            indirizzo = indirizzo_;
            email = email_;
        }

        


    }
}
