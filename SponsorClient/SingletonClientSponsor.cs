using System;
using System.Runtime.Remoting.Lifetime;

namespace SponsorClient {

    public class SingletonClientSponsor: MarshalByRefObject, ISponsor {
        private readonly String _name;

        public SingletonClientSponsor(String name) {
            _name = name;
            Console.WriteLine("{0}: Создание объекта класса SingletonClientSponsor", _name);
        }
      
        public TimeSpan Renewal(ILease leaseInfo) {
            Console.WriteLine("{0}: SingletonClientSponsor.Renewal()", _name);
            return TimeSpan.FromSeconds(6);
        }

        public override string ToString() {
            return _name;
        }
    }

}
