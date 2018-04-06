using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using System.Net;


namespace SendMessage
{
    class Send
    {
        static void Main(string[] args)
        {
          


            SendMessageHelper.SendHelper.MessageSend();
        }
    }
}
