using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecieveMessageHelper
{
    public class RecieveHelper
    {
        public static void MessageRecieve()
        {

            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest"; //User Rabbitmq default
            factory.Password = "guest"; //default password

            try
            {
                using (var connection = factory.CreateConnection())  //Releasing all the resources.
                using (var channel = connection.CreateModel()) //Releasing all the resources.
                {
                    channel.QueueDeclare(queue: "Name",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        string name = message.Split(',').Last();

                        Console.WriteLine("Recieved Message : {0} ", message);

                        Console.WriteLine();

                        Console.WriteLine("Hello {0}, I am your father!", name);
                    };
                    channel.BasicConsume(queue: "Name",
                                         autoAck: true,
                                         consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
            catch (Exception)
            {

                throw;
            }

       

        }
    }
}
