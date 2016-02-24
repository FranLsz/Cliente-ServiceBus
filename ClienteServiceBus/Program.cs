using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using ServiceBus;

namespace ClienteServiceBus
{
    class Program
    {
        static void Main(string[] args)
        {
            var cf = new ChannelFactory<IServicioSaludo>(new NetTcpRelayBinding(), new EndpointAddress(ServiceBusEnvironment.CreateServiceUri("sb", "Demo444", "saludo")));

            cf.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior()
            {
                TokenProvider = TokenProvider.CreateSharedSecretTokenProvider("owner", "58A9PGyNb5Qayh8zkYxAj0cDtAKKjlRcyvoyqJSr8do=")
            });

            var ch = cf.CreateChannel();
            Console.WriteLine(ch.GetSaludo("es"));
            cf.Close();

            Console.Read();
        }
    }
}
