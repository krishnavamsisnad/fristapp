using Sieve.Attributes;
using System;
using System.Collections.Generic;

namespace Dbapproch.Models;

public partial class Cakesdata
{
    public int Id { get; set; }

    [Sieve(CanFilter = true,CanSort = true)] public string? Nameofcake { get; set; }

    [Sieve(CanFilter = true, CanSort = true)] public int Prince { get; set; }
}
