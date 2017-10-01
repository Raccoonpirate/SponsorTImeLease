using System;
using System.Runtime.Remoting.Lifetime;

namespace SponsorClient {

    public class CaoClientSponsor: MarshalByRefObject, ISponsor {
        private readonly String _name;

        public CaoClientSponsor(String name) {
            _name = name;
            Console.WriteLine("{0}: Создание объекта класса CaoClientSponsor", _name);
        }
      
        public TimeSpan Renewal(ILease leaseInfo) {
            Console.WriteLine("{0}: CaoClientSponsor.Renewal()", _name);
            return TimeSpan.FromSeconds(6);
        }

        public override string ToString() {
            return _name;
        }
    }

}
