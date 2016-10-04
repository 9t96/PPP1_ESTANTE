using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP_ESTANTE1
{
    public class Estante
    {
        protected sbyte _capacidad;
        protected List<Producto> _productos;

        private Estante()
        {
            this._productos = new List<Producto>();
        }

        public Estante(sbyte capacidad)
            : this()
        {
            this._capacidad = capacidad;
        }

        public float ValorEstanteTotal
        {
            get {
                return this.GetValorEstante();
            }
        }

        public List<Producto> GetProductos()
        {
            return this._productos;
        }

        public static string MostrarEstante(Estante est)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Contenido estante: ");
            str.AppendLine("Capacidad: " + est._capacidad);
            str.AppendLine("Valor total estante: " + est.ValorEstanteTotal);


            foreach (var item in est.GetProductos())
            {
                if (item is Gaseosa)
                    str.AppendLine(((Gaseosa)item).MostrarGaseosa());
                if (item is Jugo)
                    str.AppendLine(((Jugo)item).MostrarJugo());
                if(item is Galletita)
                    str.AppendLine(Galletita.MostrarGalletita(((Galletita)item)));
            }

            return str.ToString();
        }

        public static bool operator ==(Estante estante, Producto prod)
        {
            foreach (var item in estante.GetProductos())
            {
                if (item == prod)
                    return true;
            }

            return false;
        }

        public static bool operator !=(Estante estante, Producto prod)
        {
            foreach (var item in estante.GetProductos())
            {
                if (item != prod)
                    return true;
            }

            return false;
        }

        public static bool operator +(Estante est, Producto prod)
        {
            if (est._productos.Count < est._capacidad && (!(est == prod)))
            {
                est._productos.Add(prod);
                return true;
            }

            return false;
        }

        public static Estante operator -(Estante est, Producto prod)
        {
            if (est == prod)
            {
                est._productos.Remove(prod);
                return est;
            }

            return est;
        }

        public static Estante operator -(Estante est, ETipoProducto tipo)
        {
            List<Producto> lista = est._productos;
            for (int i = 0; i < lista.Count; i++)
            {
                if (tipo == ETipoProducto.Galletita && (lista[i] is Galletita))
                {
                    lista.Remove(lista[i]);
                }
                else if (tipo == ETipoProducto.Gaseosa && (lista[i] is Gaseosa))
                {
                    lista.Remove(lista[i]);
                }
                else if (tipo == ETipoProducto.Jugo && (lista[i] is Jugo))
                {
                    lista.Remove(lista[i]);
                }
                else
                {
                    if (tipo == ETipoProducto.Todos)
                    {
                        lista.Clear();
                    }
                }
            }
            return est;
        }

        public float GetValorEstante(ETipoProducto tipo)
        {
            float total = 0;

            foreach (Producto item in this._productos)
            {
                if (tipo == ETipoProducto.Jugo && item is Jugo)
                {
                    total += item.precio;
                }
                else if (tipo == ETipoProducto.Galletita && item is Galletita)
                {
                    total += item.precio;

                }
                else if (tipo == ETipoProducto.Gaseosa && item is Gaseosa)
                {
                    total += item.precio;
                }
            }

                    return total;
        }

        private float GetValorEstante()
        {
            float total = 0;

            foreach (var item in this.GetProductos())
            {
                total += item.precio;
            }

            return total;
        }
    }
}
