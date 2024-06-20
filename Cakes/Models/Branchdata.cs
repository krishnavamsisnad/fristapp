using Sieve.Attributes;

namespace Cakes.Models
{
    public class Branchdata
    {
        [Sieve(CanFilter = true, CanSort = true)] public int Id { get; set; }
     [Sieve (CanFilter =true,CanSort=true)]   public string Name { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string Location { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string Review { get; set; }
    }
}
