using System;
using System.Runtime.Remoting.Lifetime;

namespace SponsorLibrary {

    interface IMyRegSponsor: IDisposable {
        void MyRegistration(ISponsor sponsor);
        String GetId();
    }

}
