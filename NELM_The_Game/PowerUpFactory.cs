using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class PowerUpFactory //Sirve para la fácil creación de variables con código similar, pero diferente efecto. Se apoya en las interfaces para lograrlo.
    {
        public enum Powers  {Invincibility, SuperSpeed} //Enumeramos todas las variables que se tendrán.

        public static IPowerUp CreatePowerUp(float posX, float posY, Powers powerUp) //Determinamos las referencias necesarias para la creación de una variable.
        {
            switch (powerUp) //En función del tipo de variable que queramos, es lo que se creará.
            {
                case Powers.Invincibility:
                    {
                        Engine.Debug("INVINCIBILITY");
                        return new PowerUp(posX, posY, 0.1f);
                    }
                case Powers.SuperSpeed:
                    {
                        Engine.Debug("SUPERSPEED");
                        return new PowerUp2(posX, posY, 0.1f);
                    }
                default: 
                    Engine.Debug("FALLA");
                    return null;
            }
        }
    }
}
