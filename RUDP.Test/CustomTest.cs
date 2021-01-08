using System;
using System.Text;
using System.Threading;

namespace RUDP.Test
{
    public class CustomTest
    {
        public CustomTest()
        {
            RUDPConnection s = new RUDPConnection();
            RUDPConnection c = new RUDPConnection();

            s.Listen("127.0.0.1", 80);
            c.Connect("127.0.0.1", 80);

            int counter = 0;

            //Listen for the next 500 packets
            s.OnPacketReceived += (RUDPPacket p) =>
            {
                Console.WriteLine("##### " + Encoding.UTF8.GetString(p.Data, 0, p.Data.Length));
                counter++;
            };

            //Send test data
            for (int i = 0; i < 200; i++)
            {
                c.Send("test" + i.ToString());
            }

            if(c.State != ConnectionState.CLOSED)
            {
                c.Disconnect();
            }

            if(s.State != ConnectionState.CLOSED)
            {
                s.Disconnect();
            }           
        }
    }
}
