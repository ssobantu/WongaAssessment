using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecieveMessage
{
    class Recieve
    {
        static void Main(string[] args)
        {
            //call helper class for message recieve to handle message reciept.
            RecieveMessageHelper.RecieveHelper.MessageRecieve();
        }
    }
}
