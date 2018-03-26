using System.Collections.Generic;

namespace Scene3.API.GoogleMapsGeocode {
    public class Response {
        public List<Result> results { get; set; }
        public string status { get; set; }
    }
}