using System;
using System.Collections.Generic;

namespace Retrotapes.DAL.Models
{
    public partial class CustomerSpendning
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public int? Antaletbetalningar { get; set; }

        public decimal? Dyrast { get; set; }

        public decimal? Billigast { get; set; }

        public decimal? Medelkostnad { get; set; }

        public decimal? Totalbetalning { get; set; }

        public int? UnikaProdukter { get; set; }
    }
}