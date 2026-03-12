using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Shared
{
    public class Producto
    {
        public int Id { get; set; } //Not is necesary add notation for indicated what is a Id, pq use the name ID
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
