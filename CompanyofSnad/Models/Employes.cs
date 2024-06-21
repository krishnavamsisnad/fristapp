namespace CompanyofSnad.Models
{
    public class Employes
    {
        public int EmployeId { get; set; }//p.k
        public string EmployeName { get; set; }
        public string EmployePhone { get; set; }
        public virtual Employes Employess { get; set; }
        public virtual Employedetailes Employedetailes { get; set; }//Refrence navi dependec
        public virtual int EmployeeId { get; set; } 
        public virtual Manager Manager { get; set; }    

    }
}
