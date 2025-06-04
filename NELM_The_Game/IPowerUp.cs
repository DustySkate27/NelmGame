using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public interface IPowerUp
    {
        event Action OnSpecialGain;
        void Update();
        void SpecialPower();
        bool CheckCollisions(Transform transform);
        void Render();
    }
}
