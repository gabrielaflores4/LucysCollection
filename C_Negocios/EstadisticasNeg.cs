using C_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Negocios
{
    public class EstadisticasNeg
    {
        private readonly EstadisticasDatos _datos = new EstadisticasDatos();

        //Resumen de stock
        public (int Disponible, int BajoStock, int SinStock) ObtenerResumenStock()
        {
            return _datos.ObtenerResumenStock();
        }

        //Ventas mensuales (formatea meses)
        public Dictionary<string, decimal> ObtenerVentasMensualesFormateadas()
        {
            var ventasCrudas = _datos.ObtenerVentasPorMes();
            var ventasFormateadas = new Dictionary<string, decimal>();

            foreach (var kvp in ventasCrudas)
            {
                string[] partes = kvp.Key.Split('-');
                string nombreMes = ObtenerNombreMes(partes[1]);
                ventasFormateadas.Add($"{nombreMes} {partes[0]}", kvp.Value);
            }

            return ventasFormateadas;
        }

        private string ObtenerNombreMes(string numeroMes)
        {
            return numeroMes switch
            {
                "01" => "Enero",
                "02" => "Febrero",
                "03" => "Marzo",
                "04" => "Abril",
                "05" => "Mayo",
                "06" => "Junio",
                "07" => "Julio",
                "08" => "Agosto",
                "09" => "Septiembre",
                "10" => "Octubre",
                "11" => "Noviembre",
                "12" => "Diciembre",
                _ => "Mes Inválido"
            };
        }

        //Producto más vendido
        public string ObtenerProductoMasVendido()
        {
            return _datos.ObtenerProductoTop();
        }

        //Ventas diarias
        public decimal ObtenerVentasDiarias()
        {
            return _datos.ObtenerVentasDiarias();
        }

        //Total de productos
        public int ObtenerTotalProductos()
        {
            return _datos.ObtenerTotalProductos();
        }
    }
}

