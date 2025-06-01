using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PowerUp : GameObject
    {
        private readonly Animation currentAnimation;
        private LevelController levelController;
        public Transform PowerUpTransform => transform;

        private int scale = 32;
        private float speedAnimation = 0.1f;

        public PowerUp(float positionX, float positionY) //Constructor
        {
            levelController = GameManager.Instance.LevelController;

            transform = new Transform(positionX, positionY, scale, scale); //Se llama a la posición del Power Up

            List<Image> powerUpFrames = new List<Image>(); //Lista de frames

            for (int i = 0; i < 10; i++) //Carga de frames
            {
                Image frames = Engine.LoadImage($"assets/powerup/powerup0{i}.png");
                powerUpFrames.Add(frames);
            }

            currentAnimation = new Animation(powerUpFrames, speedAnimation, true); // Animación de Power Up
            
        }

        public void Update()
        {
            currentAnimation.Update(); //Actualizacion de animacion
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentImage, transform.PosX, transform.PosY); //Renderizado de power up
        }

        public void GainInvincibility()
        {
            levelController.Score.AddPowerUpPoints(50);
            levelController.PowerUp = null;
            levelController.Player1.PlayerController.Invincibility = true;
            Engine.Debug("Invencibilidad activada");
            levelController.Player1.PlayerController.InvincibilityTimer = 0f;
        }

    }
}