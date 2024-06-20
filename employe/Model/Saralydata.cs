namespace Employe.Model
{
    public class Saralydata
    {
        public int Id { get; set; }
        public int EmployeId { get; set; }
        public string Employename { get; set; }
        public int Prince { get; set; }
        public virtual Employ? Employ { get; set; }
    }
}
