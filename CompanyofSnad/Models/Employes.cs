namespace CompanyofSnad.Models
{
    public class Employes
    {
        public int EmployeId { get; set; }//p.k
        public string EmployeName { get; set; }
        public string EmployePhone { get; set; }
        public Employedetailes Employedetailes { get; set; }//Refrence navi dependec
        public int EmployeeId { get; set; } 
        public Manager Manager { get; set; }    

    }
}
