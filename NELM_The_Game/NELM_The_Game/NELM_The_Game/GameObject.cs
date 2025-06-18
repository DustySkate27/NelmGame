using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class GameObject //Clase para todos los objetos del juego que sean acordes a los datos propuestos
    {
        protected Transform transform;
        protected Renderer renderer;

        public Transform Transform => transform;

        public Renderer Renderer => renderer;
    }
}
