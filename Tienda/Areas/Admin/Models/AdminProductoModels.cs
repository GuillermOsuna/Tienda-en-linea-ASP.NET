using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda.Areas.Admin.Models
{
    public class AdminProductoModels
    {
        public AdminProductoModels()
        {

        }
        public string ProductoId { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public decimal Precio { get; set; }
    }
    public class CrearProductoModel
    {
        public string ProductoId { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public decimal Precio { get; set; }
    }
}