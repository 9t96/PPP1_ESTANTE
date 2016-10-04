using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP_ESTANTE1
{
    public class Jugo:Producto
    {
        protected ESaborJugo _sabor;

        public Jugo(int codigo, float precio, EMarcaProducto marca, ESaborJugo sabor)
            :base(codigo,precio,marca)
        {
            this._sabor = sabor;
        }

        public string MostrarJugo()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(Producto.MostrarProducto(this));
            str.AppendLine("Sabor: " + this._sabor);

            return str.ToString();
        }
    }
}
