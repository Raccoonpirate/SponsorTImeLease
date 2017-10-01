using System;
using System.Runtime.Remoting;

namespace SponsorServer {

    class Server {
        static void Main() {
            RemotingConfiguration.Configure("SponsorServer.exe.config", false);

            Console.WriteLine("Server started. Press Enter to end ...");
            Console.ReadLine();
        }
    }

}
