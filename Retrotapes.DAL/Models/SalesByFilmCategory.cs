﻿using System;
using System.Collections.Generic;

namespace Retrotapes.DAL.Models
{
    public partial class SalesByFilmCategory
    {
        public string Category { get; set; } = null!;

        public decimal? TotalSales { get; set; }
    }
}