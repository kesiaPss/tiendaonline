
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.BL
{
    public class ReportedeVentasPorProductoBL
    {
        Contexto _contexto;

        public List<ReportedeVentasPorProducto> ListadeVentasPorProducto {get; set;}

         public ReportedeVentasPorProductoBL()
        
        {
            _contexto = new Contexto();
            ListadeVentasPorProducto = new List<ReportedeVentasPorProducto>();
        }

        public List<ReportedeVentasPorProducto> ObtenerVentasPorProducto()
        {
            ListadeVentasPorProducto = _contexto.OrdenDetalle
                .Include("Producto")
                .Where(r => r.Orden.Activo)
                .GroupBy(r => r.Producto.Descripcion)
                .Select(r => new ReportedeVentasPorProducto()
                {
                    Producto = r.Key,
                    Cantidad = r.Sum(s => s.Cantidad),
                    Total = r.Sum(s => s.Total)
                }).ToList();
           
             return ListadeVentasPorProducto;

           
        }
    }

 }
