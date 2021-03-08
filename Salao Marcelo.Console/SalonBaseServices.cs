using Salao_Marcelo.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Salao_Marcelo.CLI
{
    public class SalonBaseServices
    {
        public static void AddProfessionalOptions(Salon salon)
        {
            Professional professional = new Professional();
            Console.Write("Digite o nome: ");
            professional.Name = Console.ReadLine();
            Console.Write("Digite o telefone: ");
            professional.Phone = Console.ReadLine();
            Console.Write("Digite o endereço: ");
            professional.Address = Console.ReadLine();
            Console.Write("Digite a comissão em %: ");
            Decimal comission;
            Decimal.TryParse(Console.ReadLine(), out comission);
            professional.Commission = comission;
            salon.Add(professional);
        }

        public static void AddClientOptions(Salon salon)
        {
            Client client = new Client();
            Console.Write("Digite o nome: ");
            client.Name = Console.ReadLine();
            Console.Write("Digite o telefone: ");
            client.Phone = Console.ReadLine();
            Console.Write("Digite o endereço: ");
            client.Address = Console.ReadLine();
            salon.Add(client);
        }

        public static void AddServiceOptions(Salon salon)
        {
            Service service = new Service();
            Console.Write("Digite o nome: ");
            service.Name = Console.ReadLine();
            Console.Write("Digite o tempo em minutos: ");
            int timeInMinutes;
            int.TryParse(Console.ReadLine(), out timeInMinutes);
            service.TimeInMinutes = timeInMinutes;
            Console.Write("Digite o valor do serviço: ");
            Decimal price;
            Decimal.TryParse(Console.ReadLine(), out price);
            service.Price = price;
            salon.Add(service);
        }

        public static void RemoveProfessionalOptions(Salon salon)
        {
            string message = "Digite o id do profissional\n";
            foreach (Professional professional in salon.Professionals)
            {
                message += $"{professional.Id} - {professional.Name}\n";
            }
            message += $"{salon.Professionals.Count + 1} - Sair\n";
            Console.WriteLine(message);
            int id;
            int.TryParse(Console.ReadLine(), out id);
            if (salon.Professionals.Exists(p => p.Id == id)) {

            }
        }

    }
}
