namespace Address.Model
{
    public class Addressdata
    {
        public int PersonId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public  Persondata Persondata { get; set; }
    }
}
