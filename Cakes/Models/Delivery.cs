namespace Cakes.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public int CakesId { get; set; }
        public string Name { get; set; }
        public int Phonenumber { get; set; }
        public Cakesdata Cakesdata { get; set; }    
    }
}
