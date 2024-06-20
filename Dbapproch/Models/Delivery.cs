using System;
using System.Collections.Generic;

namespace Dbapproch.Models;

public partial class Delivery
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Phonenumber { get; set; }
    public DateTime? CreatedDate { get; set; }
}
