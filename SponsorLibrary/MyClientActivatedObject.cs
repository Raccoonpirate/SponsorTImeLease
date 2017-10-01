using System;
using System.Runtime.Remoting.Lifetime;

namespace SponsorLibrary {

    //Вызывается на сервере
    public class MyClientActivatedObject : MarshalByRefObject, IMyRegSponsor {
        private readonly MainSponsor _mainSponsor;
        private String _id;

        public MyClientActivatedObject() {
            _mainSponsor = new MainSponsor(this);
            Console.WriteLine("##### Создание объекта класса MyClientActivatedObject");
        }

        public void Dispose() {
            //Вызывается в случае отключения клиента от сервера
            Console.WriteLine("##### {0}: MyClientActivatedObject.Dispose()", _id);
            GC.SuppressFinalize(this);
        }

        public void Run() {
            Console.WriteLine("{0}: MyClientActivatedObject.Run()", _id);
        }

        public override object InitializeLifetimeService() {
            var leaseInfo = (ILease) base.InitializeLifetimeService();

            if (leaseInfo != null) {
                leaseInfo.Register(_mainSponsor);
            }

            return leaseInfo;
        }

        public void MyRegistration(ISponsor sponsor) {
            //Регистрируем у главного спонсора спонсор клиента
            _mainSponsor.AddSponsor(sponsor);
        }

        public void SetId(String id) {
            _id = "CAO " + id;
        }

        public string GetId() {
            return _id;
        }
    }

}
