using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP_ESTANTE1
{
    public class Gaseosa:Producto
    {
        protected float _litros;

        public Gaseosa(int codigo, float precio, EMarcaProducto marca, float litros)
            : base(codigo, precio, marca)
        {
            this._litros = litros;
        }

        public Gaseosa(Producto prod, float litros)
            : this((int)prod, prod.precio, prod.marca, litros)
        { 
        
        }

        public string MostrarGaseosa()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(Producto.MostrarProducto(this));
            str.AppendLine("Litros: " + this._litros);

            return str.ToString();
        }

    }
}
