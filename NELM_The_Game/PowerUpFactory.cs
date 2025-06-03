using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class PowerUpFactory
    {
        public enum Powers  {Invincibility, SuperSpeed}

        public static IPowerUp CreatePowerUp(float posX, float posY, Powers powerUp)
        {
            switch (powerUp)
            {
                case Powers.Invincibility:
                    {
                        return new PowerUp(posX, posY);
                    }
                case Powers.SuperSpeed:
                    {
                        return new PowerUp(posX, posY);
                    }
            }

            return null;
        }
    }
}
