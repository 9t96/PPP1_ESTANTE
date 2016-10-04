using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP_ESTANTE1
{
    public class Galletita:Producto
    {
        protected float _peso;

        public Galletita(int codigo,float precio,EMarcaProducto marca,float peso)
            :base(codigo,precio,marca)
        {
            this._peso = peso;   
        }

        public static string MostrarGalletita(Galletita galleta)
        {
            StringBuilder str = new StringBuilder();
            
            str.AppendLine(Producto.MostrarProducto(galleta));
            str.AppendLine("Peso: " + galleta._peso);

            return str.ToString();
        }
    }
}
