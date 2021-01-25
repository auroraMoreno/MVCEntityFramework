using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFramework.Models
{
    public class Deportivo : Coche, ICoche
    {
        public Deportivo(String marca, String modelo, String imagen, int velocidadmaxina)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Imagen = imagen;
            this.VelocidadMaxima = velocidadmaxina;
            this.Velocidad = 0;
        }
        public Deportivo()
        {
            this.Marca = "deport";
            this.Modelo = "ni diea";
            this.Imagen = "chessboard.png";
            this.Velocidad = 0;
            this.VelocidadMaxima = 240;
        }
    }
}
