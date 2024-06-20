namespace CompanyofSnad.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public ICollection<Employes> Employes { get; set; }//COLLECTIN navi
    }
}
