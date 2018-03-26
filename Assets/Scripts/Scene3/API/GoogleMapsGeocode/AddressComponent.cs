using System.Collections.Generic;

namespace Scene3.API.GoogleMapsGeocode {
    public class AddressComponent {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }
}