namespace Address.Model
{
    public class Persondata
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string Address { get; set; }
  
        public virtual Addressdata Addressdata { get; set; }
    }
}
