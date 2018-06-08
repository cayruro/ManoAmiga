using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PruebaUnitaria
{
    [TestClass]
    public class UnitTest1
    {
        List<Mano_Amiga.ArticuloClase> listaArticulo = new List<Mano_Amiga.ArticuloClase>();
        [TestMethod]
        public void TestReserva()
        {
            
            Mano_Amiga.ArticuloClase a = new Mano_Amiga.ArticuloClase("imagenes\\comida1.jpeg", "italiano", "D", DateTime.Now, "pizza");
            a.Reservar(listaArticulo);
        }

        public void llenarlista(List<Mano_Amiga.ArticuloClase> listaArticulo)
        {
            listaArticulo.Add(new Mano_Amiga.ArticuloClase("imagenes\\comida1.jpeg", "italiano", "D", DateTime.Now, "pizza"));
        }


    }
}

