using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;

namespace SponsorLibrary {

    class MainSponsor : ISponsor {
        //Список всех спонсоров (клиентов)
        private readonly List<ISponsor> _listSponsors;
        private readonly IMyRegSponsor _myRegSponsor;

        public MainSponsor(IMyRegSponsor myRegSponsor) {
            _listSponsors = new List<ISponsor>();
            _myRegSponsor = myRegSponsor;
        }

        public TimeSpan Renewal(ILease lease) {
            do {
                try {
                    Console.WriteLine("{0}: MainSponsor.Renewal()", _myRegSponsor.GetId());
                    return _listSponsors[0].Renewal(lease);
                }
                catch (Exception) {
                    Console.WriteLine("##### {0}: Client Disconnected", _myRegSponsor.GetId());
                    _listSponsors.RemoveAt(0);

                    if (_listSponsors.Count == 0) {
                        //Если список всех кому нужно спонсировать время пуст, то удаляем объект спонсора
                        _myRegSponsor.Dispose();
                    }
                }

            } while (_listSponsors.Count > 0);

            return TimeSpan.FromSeconds(0);
        }

        public void AddSponsor(ISponsor sponsor) {
            _listSponsors.Add(sponsor);
        }
    }

}
