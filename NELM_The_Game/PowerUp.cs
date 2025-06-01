using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{

    public class PowerUp : GameObject
    {
        public event Action OnInvincibilityGain;

        private readonly Animation currentAnimation;
        private LevelController levelController;
        public Transform PowerUpTransform => transform;

        private int scale = 32;

        public PowerUp(float positionX, float positionY) //Constructor
        {
            levelController = GameManager.Instance.LevelController;

            transform = new Transform(positionX, positionY, scale, scale); //Se llama a la posición del Power Up

            renderer = new Renderer(transform, "powerup/powerup0", 10, 0.1f, true);
            
        }

        public void Update()
        {
            renderer.AnimationUpdate(); //Actualizacion de animacion
        }

        public void GainInvincibility()
        {
            levelController.Score.AddPowerUpPoints(50);
            OnInvincibilityGain?.Invoke();
            //levelController.PowerUp = null;
            //levelController.Player1.PlayerController.Invincibility = true;
            Engine.Debug("Invencibilidad activada");
            //levelController.Player1.PlayerController.InvincibilityTimer = 0f;
        }

    }
}