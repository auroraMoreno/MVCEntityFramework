using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFramework.Models
{
    public interface ICoche
    {
        //solamente es una declaración de características compuestas por metodos y props 
        //indicar todo lo que tendira cualqueir coche que queramos o cualqueir depor
        String Marca { get; set; }
        String Modelo { get; set; }
        String Imagen { get; set; }
        int Velocidad { get; set; }
        int VelocidadMaxima { get; set; }
        void Acelerar();
        void Frenar();

    }
}
