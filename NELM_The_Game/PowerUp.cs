using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{

    public class PowerUp : GameObject, IPowerUp
    {
        public event Action OnSpecialGain;

        private LevelController levelController;
        public Transform PowerUpTransform => transform;

        private int scale = 32;

        public PowerUp(float positionX, float positionY) //Constructor
        {
            levelController = GameManager.Instance.LevelController;

            transform = new Transform(positionX, positionY, scale, scale); //Se llama a la posición del Power Up
            
            if (levelController.PowerSelected == 0)
            renderer = new Renderer(transform, "powerup/powerup0", 10, 0.1f, true);
            if (levelController.PowerSelected == 1)
            renderer = new Renderer(transform, "powerup2/powerup20", 9, 0.1f, true);

        }

        public void Update()
        {
            renderer.AnimationUpdate(); //Actualizacion de animacion
        }

        public void SpecialPower()
        {
            if (levelController.PowerSelected == 0)
                levelController.Score.AddPowerUpPoints(50);
            if (levelController.PowerSelected == 1)
                levelController.Score.AddPowerUpPoints(70);
            OnSpecialGain?.Invoke();
        }

    }
}