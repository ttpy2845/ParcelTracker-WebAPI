namespace ParcelTrackerWebAPI.Models
{
    namespace ParcelDeleteModel
    { 
        public class ParcelDeleteModel
        {
            public int code { get; set; }
            public Data data { get; set; }
        }

        public class Accepted
        {
            public string number { get; set; }
            public int carrier { get; set; }
        }

        public class Data
        {
            public List<Accepted> accepted { get; set; }
            public List<Rejected> rejected { get; set; }
        }

        public class Error
        {
            public int code { get; set; }
            public string message { get; set; }
        }

        public class Rejected
        {
            public string number { get; set; }
            public Error error { get; set; }
        }
    }
}
