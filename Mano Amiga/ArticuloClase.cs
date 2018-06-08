using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mano_Amiga
{
   public class ArticuloClase
    {
        private Mano_AmigaEntities1 db;

        string foto;
        string descripcion;
        string estado;
        DateTime fechaDonacion;
        string nombre;
        DateTime fechaReserva;

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public ArticuloClase() { }

        /// <summary>
        /// constructor con parametros
        /// </summary>
        public ArticuloClase(string foto, string descripcion, string estado,  DateTime fechaDonacion, string nombre)
        {
            this.foto = foto;
            this.descripcion = descripcion;
            this.estado = estado;
            this.fechaDonacion = fechaDonacion;
            this.nombre = nombre;
        }

        /// <summary>
        /// Reservar el articulo de la lista articulos
        /// </summary>
        /// <param name="articulos">lista que contiene los articulos</param>
        /// <param name="id">int, id del articulo </param>
        public bool Reservar(List<Mano_Amiga.ArticuloClase> articulos)
        {
            bool res;
            if(this.estado.Equals("D"))
            {
                estado = "R";
                this.fechaReserva = DateTime.Now.AddDays(15);
                res = true;
            } else
            {
                res = false;
            }
            return res;

        }
        

    }
}
