using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessageHelper
{
    public class SendHelper
    {
        public static void MessageSend()
        {
            Console.WriteLine("Enter Name:"); // Prompt for user input
            string name = Console.ReadLine(); // Get string from user                    

            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest"; //User Rabbitmq default
            factory.Password = "guest"; //default password    

            try
            {
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "Name",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                        string message = name;
                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(exchange: "",
                              routingKey: "Name",
                              basicProperties: null,
                              body: body);
                        Console.WriteLine("Sent Message: {0}", "Hello my name is, " + message);

                        Console.WriteLine(" Press [enter] to exit.");
                        Console.ReadLine();

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }         

      
        }
    }
}
