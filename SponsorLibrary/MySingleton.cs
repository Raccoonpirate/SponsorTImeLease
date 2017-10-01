using System;
using System.Runtime.Remoting.Lifetime;

namespace SponsorLibrary {

    //Вызывается на сервере
    public class MySingleton: MarshalByRefObject, IMyRegSponsor {
        private readonly MainSponsor _mainSponsor;
        private readonly String _id;

        public MySingleton() {
            _mainSponsor = new MainSponsor(this);
            _id = "Singleton";
            Console.WriteLine("##### Создание объекта класса MySingleton");
        }

        public void Dispose() {
            //Вызывается в случае полного отсутствия клиентов для спонсирования
            Console.WriteLine("##### {0}: MySingleton.Dispose()", _id);
            GC.SuppressFinalize(this);
        }

        public void Run() {
            Console.WriteLine("{0}: MySingleton.Run()", _id);
        }

        public override object InitializeLifetimeService() {
            var leaseInfo = (ILease)base.InitializeLifetimeService();

            if (leaseInfo != null) {
                leaseInfo.InitialLeaseTime = TimeSpan.FromSeconds(8);
                leaseInfo.RenewOnCallTime = TimeSpan.FromSeconds(4);

                leaseInfo.Register(_mainSponsor);
            }

            return leaseInfo;
        }

        public void MyRegistration(ISponsor sponsor) {
            _mainSponsor.AddSponsor(sponsor);
        }

        public string GetId() {
            return _id;
        }
    }

}
