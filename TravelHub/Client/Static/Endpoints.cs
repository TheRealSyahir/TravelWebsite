using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHub.Client.Static
{
    public static class Endpoints
    {
        private static readonly string prefix = "api";

        public static readonly string CitiesEndPoint = $"{prefix}/cities";
        public static readonly string LocationsEndPoint = $"{prefix}/locations";
        public static readonly string StaffsEndPoint = $"{prefix}/staffs";
    }
}
