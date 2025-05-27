using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PowerUp
    {
        private readonly Transform powerUpTransform;
        private readonly Animation powerUpAnim;

        private LevelController levelController;

        public Transform PowerUpTransform => powerUpTransform;

        public PowerUp(float positionX, float positionY) //Constructor
        {
            levelController = GameManager.Instance.LevelController;

            powerUpTransform = new Transform(positionX, positionY, 32, 32); //Se llama a la posición del Power Up

            List<Image> powerUpFrames = new List<Image>(); //Lista de frames

            for (int i = 0; i < 10; i++) //Carga de frames
            {
                Image frames = Engine.LoadImage($"assets/powerup/powerup0{i}.png");
                powerUpFrames.Add(frames);
            }

            powerUpAnim = new Animation(powerUpFrames, 0.1f, true); // Animación de Power Up
            
        }

        public void Update()
        {
            powerUpAnim.Update(); //Actualizacion de animacion
        }

        public void Render()
        {
            Engine.Draw(powerUpAnim.CurrentImage, powerUpTransform.PosX, powerUpTransform.PosY); //Renderizado de power up
        }

        public void GainInvincibility()
        {
            levelController.Score.AddPowerUpPoints(50);
            levelController.PowerUp = null;
            levelController.Player1.Invincibility = true;
            Engine.Debug("Invencibilidad activada");
            levelController.Player1.PlayerController.InvincibilityTimer = 0f;
        }

    }
}