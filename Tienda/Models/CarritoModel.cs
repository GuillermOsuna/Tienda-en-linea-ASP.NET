using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda.Models
{
    public class CarritoModel
    {
        public CarritoModel()
        {
            Articulos = new List<PartidaCarritoModel>();
        }

        public List<PartidaCarritoModel> Articulos { get; private set; }
        public void AgregarArticulo(PartidaCarritoModel partida)
        {
            Articulos.Add(partida);
            foreach (var a in Articulos) 
            {
                if (a.Codigo == partida.Codigo)
                {
                    a.Cantidad = a.Cantidad + partida.Cantidad;
                    return;
                }
            }
            Articulos.Add(partida);
        }
        public void QuitarArticulo(PartidaCarritoModel partida)
        {
            PartidaCarritoModel index = null;
            index = Articulos.FirstOrDefault(a => a.Codigo == partida.Codigo);
            if (index != null) 
            {
                Articulos.Remove(index);
            }
        }
        public void vaciar()
        {
            Articulos.Clear();
        }
        public int Cantidad
        {
            get
            {
                return Articulos.Count;
            }
        }
        public decimal Importe
        {
            get
            {
                return Articulos.Sum(a => a.Importe);
                //decimal importe=0;
                //foreach (var p in Articulos)
                //{
                  //  importe += p.Cantidad * p.Precio;
                //}
                 //importe;
                    
            }
        }
        public bool EstaVacio 
        {
            get 
            {
                return Articulos.Count == 0;
            }
        }

    }

    public class PartidaCarritoModel
    {
        public string Codigo {get;set;}
        public string Nombre {get;set;}
        public decimal Precio {get;set;}
        public decimal Cantidad {get;set;}
        public decimal Importe
        { get 
            {
                return this.Cantidad * this.Precio;
            }
        }
    }
}