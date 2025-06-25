using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{

    public class PowerUpInvincibility : GameObject, IPowerUp
    {
        public event Action OnSpecialGain; 

        private LevelController levelController;

        private int scale = 32;

        public PowerUpInvincibility(float positionX, float positionY, float speedAnimation)
        {
            levelController = GameManager.Instance.LevelController;

            transform = new Transform(positionX, positionY, scale, scale); 

            renderer = new Renderer(transform, "powerup/powerup0", 10, 0.1f, true);

        }

        public void Update()
        {
            renderer.AnimationUpdate();
        }

        public void SpecialPower() 
        {
            levelController.Player1.Renderer.ChangeAnimation("player/player_power1/player_power0", 3, 0.1f);
            levelController.Score.AddPowerUpPoints(30);
            levelController.Player1.ExtraPointsAvailable = true;
            OnSpecialGain?.Invoke();
        }
    }
}