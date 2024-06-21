namespace CompanyofSnad.Models
{
    public class Employedetailes
    {
        public int EmployedetailesId { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
        public string Region { get; set; }
        public int Employeid { get; set; }//f.k
        public virtual Employes Employes { get; set; }//refre navi pro
    }
}
