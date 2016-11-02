using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testWCFServiceRuner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск службы");

            try
            {
                FiasMigrator.FiasRealClient client = new FiasMigrator.FiasRealClient();
                client.Open();
                client.Runable("ambasadore");
                client.Close();

                Console.WriteLine("Приложение соединилось с сервером и отправило данные корректно!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
