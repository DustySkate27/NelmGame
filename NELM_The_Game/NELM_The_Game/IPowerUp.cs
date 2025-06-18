using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public interface IPowerUp //Es como una especia de molde para todo código asociado a esta. Su fin es estandarizar los códigos que son similares, condicionando propiedades mínimas.
    {
        event Action OnSpecialGain;
        void Update();
        void SpecialPower();
    }
}
