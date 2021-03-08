using Salao_Marcelo.Domain;
using System;

namespace Salao_Marcelo.CLI
{
    public class Program
    {
        private static Salon salon;
        static void Main(string[] args)
        {
            // Init Salon
            salon = new Salon();

            // Populate Professionals
            //AutoPopulate.PopulateProfessionals(salon);

            // Populate clients
            //AutoPopulate.PopulateClients(salon);

            // Populate Services
            //AutoPopulate.PopulateServices(salon);

            bool notExit;
            do
            {
                Console.WriteLine(@"Bem vindo ao Salão do Marcelo!
O que gostaria de fazer hoje?
1 - Marcar um horário
2 - Cancelar um horario
3 - Finalizar um serviço
4 - Adicionar um profissional
5 - Adicionar um cliente
6 - Adicionar um serviço
7 - Remover um profissional
8 - Remover um cliente
9 - Remover um serviço
0 - Sair"
                );
                switch (Console.ReadLine())
                {
                    case "1":
                        notExit = true;
                        SalonDailyServices.MakeAppointmentOptions(salon);
                        break;
                    case "2":
                        notExit = true;
                        SalonDailyServices.CancelAppointmentOptions(salon);
                        break;
                    case "3":
                        notExit = true;
                        SalonDailyServices.FinishAppointmentOptions(salon);
                        break;
                    case "4":
                        notExit = true;
                        SalonBaseServices.AddProfessionalOptions(salon);
                        break;
                    case "5":
                        notExit = true;
                        SalonBaseServices.AddClientOptions(salon);
                        break;
                    case "6":
                        notExit = true;
                        SalonBaseServices.AddServiceOptions(salon);
                        break;
                    case "7":
                        notExit = true;
                        SalonBaseServices.RemoveProfessionalOptions(salon);
                        break;
                    case "8":
                        notExit = true;
                        SalonBaseServices.RemoveClientOptions(salon);
                        break;
                    case "9":
                        notExit = true;
                        SalonBaseServices.RemoveServiceOptions(salon);
                        break;
                    case "0":
                        Console.WriteLine("Obrigado pela preferência!\nAté a próxima...");
                        notExit = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        notExit = true;
                        break;
                }
            } while (notExit);
        }

        
    }
}
