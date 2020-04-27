﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLinqExpressions
{
    class ProductInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberInStock { get; set; }
        public override string ToString() => $"Name: {Name}, Description: {Description}, Number in stock: {NumberInStock}";

    }
}
