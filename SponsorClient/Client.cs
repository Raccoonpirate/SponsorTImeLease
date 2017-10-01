using System;
using System.Net;
using System.Runtime.Remoting;
using SponsorLibrary;

namespace SponsorClient {

    class Client {
        static void Main() {
            RemotingConfiguration.Configure("SponsorClient.exe.config", false);

            String idClient = "id" + Math.Abs(DateTime.Now.GetHashCode() / 1000000);

            Console.WriteLine("Client started, {0}", idClient);

            MyClientActivatedObject myClientActivated;

            try {
                myClientActivated = new MyClientActivatedObject();
            }
            catch (WebException) {
                Console.WriteLine("Ошибка при подключении к серверу.");
                Console.ReadLine();
                return;
            }

            myClientActivated.SetId(idClient);

            myClientActivated.MyRegistration(new CaoClientSponsor("CAO " + idClient));
            myClientActivated.Run();

            MySingleton mySingleton;

            try {
                mySingleton = new MySingleton();
            }
            catch (WebException) {
                Console.WriteLine("Ошибка при подключении к серверу.");
                Console.ReadLine();
                return;
            }

            mySingleton.MyRegistration(new SingletonClientSponsor("Singleton"));
            mySingleton.Run();

            Console.WriteLine("Press Enter to end ...");
            Console.ReadLine();
        }
    }

}
