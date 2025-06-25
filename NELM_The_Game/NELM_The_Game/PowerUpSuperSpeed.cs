using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PowerUpSuperSpeed : GameObject, IPowerUp
    {
        public event Action OnSpecialGain;

        private LevelController levelController;

        private int scale = 32;

        public PowerUpSuperSpeed(float positionX, float positionY, float speedAnimation) 
        {
            levelController = GameManager.Instance.LevelController;

            transform = new Transform(positionX, positionY, scale, scale); 

            renderer = new Renderer(transform, "powerup2/powerup20", 9, 0.1f, true);

        }

        public void Update()
        {
            renderer.AnimationUpdate();
        }

        public void SpecialPower()
        {
            levelController.Player1.Renderer.ChangeAnimation("player/player_power2/player_power20", 3, 0.05f);
            levelController.Score.AddPowerUpPoints(70);
            OnSpecialGain?.Invoke();
        }

    }
}
