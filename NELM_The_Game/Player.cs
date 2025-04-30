using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Player
    {
        private PlayerController playerController;
        private Transform playerTransform;
        private Animation playerAnim;

        public PlayerController controller
        {
            get => playerController;
        }

        public Player(float positionX, float positionY)
        {
            playerTransform = new Transform(positionX, positionY, 64, 64); //Donde aparece
            playerController = new PlayerController(playerTransform); //Hacia donde se mueve

            List<Image> images = new List<Image>(); //Lista de frames

            for (int i = 0; i < 3; i++) //Se cargan los frames
            {
                Image imagen = Engine.LoadImage($"assets/player/player_idle/player_idle{i}.png");
                images.Add(imagen);
            }

            playerAnim = new Animation(images, 0.1f, true); //Animacion de player
        }

        private void CheckCollision()
        {
            for (int i = 0; i < GameManager.Instance.LevelController.EnemyList.Count; i++)
            {
                Enemy enemy = GameManager.Instance.LevelController.EnemyList[i];

                float distanceX = Math.Abs((enemy.EnemyTransform.PosX + enemy.EnemyTransform.ScaleX) - (playerTransform.PosX + playerTransform.ScaleX));
                float distanceY = Math.Abs((enemy.EnemyTransform.PosY + enemy.EnemyTransform.ScaleY) - (playerTransform.PosY + playerTransform.ScaleY));

                float sumHalfWidth = (enemy.EnemyTransform.ScaleX / 2) + (playerTransform.ScaleX / 2);
                float sumHeightWidth = (enemy.EnemyTransform.ScaleX / 2) + (playerTransform.ScaleX / 2);

                if (!playerController.Invincibility && distanceX < sumHalfWidth && distanceY < sumHeightWidth)
                {
                    GameManager.Instance.gameStage = GameState.Lose;
                    Engine.Debug("CRITICAL HIT");
                }
            }

            if (GameManager.Instance.LevelController.powerUp != null) 
            {
                PowerUp powerUp = GameManager.Instance.LevelController.powerUp;

                float powerUpDistanceX = Math.Abs((powerUp.PowerUpTransform.PosX + powerUp.PowerUpTransform.ScaleX) - (playerTransform.PosX + playerTransform.ScaleX));
                float powerUpDistanceY = Math.Abs((powerUp.PowerUpTransform.PosY + powerUp.PowerUpTransform.ScaleY) - (playerTransform.PosY + playerTransform.ScaleY));

                float sumPowerUpDistanceX = (powerUp.PowerUpTransform.ScaleX / 2) + (playerTransform.ScaleX / 2);
                float sumPowerUpDistanceY = (powerUp.PowerUpTransform.ScaleY / 2) + (playerTransform.ScaleY / 2);

                if (powerUpDistanceX < sumPowerUpDistanceX && powerUpDistanceY < sumPowerUpDistanceY)
                {
                    GameManager.Instance.LevelController.score.AddPowerUpPoints(50);
                    GameManager.Instance.LevelController.powerUp = null;
                    playerController.Invincibility = true;
                    Engine.Debug("Invencibilidad activada");
                    playerController.InvincibilityTimer = 0f;
                }
            }
        }

        public void Update()
        {
            playerController.Update();

            playerAnim.Update();

            CheckCollision();
        }

        public void Render()
        {
            Engine.Draw(playerAnim.CurrentImage, playerTransform.PosX, playerTransform.PosY);
        }

    }
}
