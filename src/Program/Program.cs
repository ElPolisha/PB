using System;
using System.Collections.Generic;
using System.ComponentModel;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact contacto1 = new Contact("Main") { Phone = "+59897206938" };
            Contact contacto2 = new Contact("Random") { Phone = "+59898414614" };
            Contact contacto3 = new Contact("Cache") { Phone = "+59899533498" };

            Phonebook phonebook1 = new Phonebook(contacto1);
            phonebook1.AddContact(contacto1);
            phonebook1.AddContact(contacto2);
            phonebook1.AddContact(contacto3);
            string[] contactos = {"Main", "Random", "Cache"};
            List<Contact> ContactosEncontrados = phonebook1.Search(contactos);
            foreach (var contacto in ContactosEncontrados)
            {
                Console.WriteLine(contacto.Name);
            }

            WhatsAppChannel canalwhatsapp = new WhatsAppChannel();
            string mensaje = "Nacional es el más grande, REY DE AMÉRICA";
            phonebook1.SendMessage(contactos, mensaje,canalwhatsapp);
        }
    }
}