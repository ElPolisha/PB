using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Phonebook
    {
        private List<Contact> persons;

        public Phonebook(Contact owner)
        {
            Owner = owner;
            persons = new List<Contact>();
        }

        public Contact Owner { get; }

        public List<Contact> Search(string[] names)
        {
            return persons.Where(person => names.Contains(person.Name)).ToList();
        }

        public void DeleteContact(Contact contact)
        {
            if (persons.Contains(contact))
            {
                persons.Remove(contact);
            }
        }

        public void AddContact(Contact contact)
        {
            if (!persons.Contains(contact))
            {
                persons.Add(contact);
            }
        }

        public void SendMessage(string[] names, string text, IMessageChannel channel)
        {
            var contacts = Search(names);

            foreach (var contact in contacts)
            {
                if (!string.IsNullOrEmpty(contact.Phone))
                {
                    var message = new Message(Owner.Phone, contact.Phone)
                    {
                        Text = text
                    };

                    try
                    {
                        channel.Send(message);
                        Console.WriteLine("El mensaje ha sido enviado");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No se envió el mensaje");
                    }
                }
            }
        }
    }
}