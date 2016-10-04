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
            Estante estante=est;
            foreach (var item in est.GetProductos())
            {
                if (item.GetType().ToString() != tipo.ToString())
                {
                    estante._productos.Remove(item);
                }
            }

            return estante;
        }

        public float GetValorEstante(ETipoProducto tipo)
        {
            float total = 0;

            foreach (var item in this.GetProductos())
            {
                if (item.GetType().ToString() == tipo.ToString())
                {
                    total += (float)item.precio;
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
