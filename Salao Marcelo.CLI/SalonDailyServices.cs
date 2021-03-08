using Salao_Marcelo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salao_Marcelo.CLI
{
    public class SalonDailyServices
    {
        public static void MakeAppointmentOptions(Salon salon)
        {
            string message = "Qual serviço?\n";
            for (int i = 0; i < salon.Services.Count; i++)
            {
                message += $"{i + 1} - {salon.Services[i].Name}\n";
            }
            message += $"{salon.Services.Count + 1} - Sair";
            Console.WriteLine(message);
            Console.ReadLine();
        }

        public static void CancelAppointmentOptions(Salon salon)
        {
            Console.WriteLine(
                @"1 - Por serviço
                2 - Por Cliente
                3 - Por Profissional
                4 - Por Horário"
            );
            Console.ReadLine();
        }

        public static void FinishAppointmentOptions(Salon salon)
        {
            Console.WriteLine(
                @"1 - Por serviço
                2 - Por Cliente
                3 - Por Profissional
                4 - Por Horário"
            );
            Console.ReadLine();
        }
    }
}
