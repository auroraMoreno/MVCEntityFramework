using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFramework.Models
{
    public class Coche : ICoche
    {
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Imagen { get; set; }
        public int VelocidadMaxima { get; set; }
        public int Velocidad { get; set; }

        public Coche()
        {
            this.Marca = "marca 1";
            this.Modelo = "f3";
            this.Imagen = "original.jpg";
            this.Velocidad = 13;
            this.VelocidadMaxima = 700;

        }

        public void Acelerar()
        {
            this.Velocidad += 10;
            if(this.Velocidad >= this.VelocidadMaxima)
            {
                this.Velocidad = this.VelocidadMaxima;
            }
        }

        public void Frenar()
        {
            this.Velocidad -= 10;
            if(this.Velocidad < 0)
            {
                this.Velocidad = 0; 
            }
        }
    }
}
