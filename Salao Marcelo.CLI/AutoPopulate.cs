using Salao_Marcelo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salao_Marcelo.CLI
{
    public class AutoPopulate
    {
        public static void PopulateProfessionals(Salon salon)
        {
            List<Professional> professionals = new List<Professional>()
            {
                new Professional()
                {
                    Id = 1,
                    Name = "José Carlos",
                    Phone = "165454654",
                    Address = "sadnaslkjdfhds",
                    Commission = .3m
                },
                new Professional()
                {
                    Id = 2,
                    Name = "Maria do Carmo",
                    Phone = "654646",
                    Address = "iuweuhfjksdf",
                    Commission = .3m
                },
                new Professional()
                {
                    Id = 3,
                    Name = "Rosangela de Souza",
                    Phone = "32132465456",
                    Address = "mnbjhagshfg",
                    Commission = .3m
                },
            };

            foreach (Professional professional in professionals)
            {
                salon.Add(professional);
            }
        }

        public static void PopulateClients(Salon salon)
        {
            List<Client> clients = new List<Client>()
            {
                new Client()
                {
                    Id = 1,
                    Name = "Roberto Carlos",
                    Phone = "54654231",
                    Address = "uiewrttrdf"
                },
                new Client()
                {
                    Id = 2,
                    Name = "Machado de Assis",
                    Phone = "78754531",
                    Address = "qwrsdfgfddf"
                },
                new Client()
                {
                    Id = 3,
                    Name = "Dwight Shrute",
                    Phone = "456487",
                    Address = "djkhdfjgh"
                },
                new Client()
                {
                    Id = 4,
                    Name = "Michael Scott",
                    Phone = "2325454",
                    Address = "zxcjhsdgf"
                },
                new Client()
                {
                    Id = 5,
                    Name = "Daenarys Targarien",
                    Phone = "8954123",
                    Address = "yhnbbgfr"
                },
            };

            foreach (Client client in clients)
            {
                salon.Add(client);
            }
        }

        public static void PopulateServices(Salon salon)
        {
            List<Service> services = new List<Service>()
            {
                new Service()
                {
                    Id = 1,
                    Name = "Corte Masculino",
                    TimeInMinutes = 20,
                    Price = 45
                },
                new Service()
                {
                    Id = 2,
                    Name = "Corte Feminino",
                    TimeInMinutes = 35,
                    Price = 60
                },
                new Service()
                {
                    Id = 3,
                    Name = "Tintura",
                    TimeInMinutes = 90,
                    Price = 130
                },
                new Service()
                {
                    Id = 4,
                    Name = "Manicure",
                    TimeInMinutes = 25,
                    Price = 25
                },
                new Service()
                {
                    Id = 5,
                    Name = "Pedicure",
                    TimeInMinutes = 35,
                    Price = 35
                },
                new Service()
                {
                    Id = 6,
                    Name = "Hidratação",
                    TimeInMinutes = 45,
                    Price = 80
                }
            };

            foreach (Service service in services)
            {
                salon.Add(service);
            }
        }
    }
}
