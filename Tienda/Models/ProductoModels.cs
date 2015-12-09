using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tienda.Areas.Admin.Models;

namespace Tienda.Models
{
    public class ProductoModels
    {
              public ProductoModels() 
        {
            
        }
        public int ID { get; set; }
        public string ProductoId { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public decimal Precio { get; set; }
    }
    public class CrearProductoModels
    {
        public CrearProductoModels() 
        {
            
        }
        public int ID { get; set; }
        public string ProductoId { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public decimal Precio { get; set; }
    }


    public class TiendaenlineaDbContext : DbContext
    {
        public DbSet<ProductoModels> Productos { get; set; }
        public DbSet<AdminCategoriaModels> Categorias { get; set; }
        
    }
}