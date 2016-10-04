using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP_ESTANTE1
{
    public class Producto
    {
        protected int _codigoBarras;
        protected float _precio;
        protected EMarcaProducto _marca;

        public Producto(int codigobarras,float precio, EMarcaProducto marca)
        {
            this._codigoBarras = codigobarras;
            this._marca = marca;
            this._precio = precio;
        }

        public EMarcaProducto marca
        {
            get{
               return this._marca;
               }
        }

        public float precio
        {
            get {
                return this._precio;
            }
        }

        public static bool operator ==(Producto prod1, Producto prod2)
        {
            if (prod1._marca == prod2._marca && prod1._codigoBarras == prod2._codigoBarras)
                return true;

            return false;
        }

        public static bool operator !=(Producto prod1, Producto prod2)
        {
            if (prod1._marca != prod2._marca && prod1._codigoBarras != prod2._codigoBarras)
                return true;

            return false;
        }

        public static bool operator ==(Producto prod1, EMarcaProducto marca)
        {
            if (marca == prod1._marca)
                return true;

            return false;
        }

        public static bool operator !=(Producto prod1, EMarcaProducto marca)
        {
            if (marca != prod1._marca)
                return true;
            
            return false;
        }

        public static explicit operator int(Producto prod1)
        {
            return prod1._codigoBarras;
        }

        protected static string MostrarProducto(Producto prod)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Marca: " + prod.marca.ToString());
            str.AppendLine("Precio: " + prod.precio);
            str.AppendLine("Codigo: " + (int)prod);

            return str.ToString();
        }






    }
}
