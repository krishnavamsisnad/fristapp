using Sieve.Attributes;
using System;
using System.Collections.Generic;

namespace Dbapproch.Models;

public partial class Branchdata
{
    public int Id { get; set; }

    [Sieve(CanFilter = true, CanSort = true)] public string? Name { get; set; }

    [Sieve(CanFilter = true, CanSort = true)] public string? Location { get; set; }

    public string? Review { get; set; }
}
