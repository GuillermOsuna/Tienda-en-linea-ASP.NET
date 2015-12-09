using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda.Areas.Admin.Models
{
    public class AdminCategoriaModels
    {
        public int ID { get; set; }
        public string CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}