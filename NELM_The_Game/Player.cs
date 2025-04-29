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
        private Animation currentAnimation;

        public PlayerController controller
        {
            get { return playerController; }
        }

        public Player(float positionX, float positionY)
        {
            playerTransform = new Transform(positionX, positionY, 64, 64);
            playerController = new PlayerController(playerTransform);

            List<Image> images = new List<Image>();

            for (int i = 0; i < 3; i++)
            {
                Image imagen = Engine.LoadImage($"assets/player/player_idle/player_idle{i}.png");
                images.Add(imagen);
            }

            currentAnimation = new Animation(images, 0.1f, true);
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
                    GameManager.Instance.GameStage = GameState.Lose;
                    Engine.Debug("CRITICAL HIT");
                }
            }

            if (GameManager.Instance.LevelController.PowerUp != null) 
            {
                PowerUp powerUp = GameManager.Instance.LevelController.PowerUp;

                float powerUpDistanceX = Math.Abs((powerUp.PowerUpTransform.PosX + powerUp.PowerUpTransform.ScaleX) - (playerTransform.PosX + playerTransform.ScaleX));
                float powerUpDistanceY = Math.Abs((powerUp.PowerUpTransform.PosY + powerUp.PowerUpTransform.ScaleY) - (playerTransform.PosY + playerTransform.ScaleY));

                float sumPowerUpDistanceX = (powerUp.PowerUpTransform.ScaleX / 2) + (playerTransform.ScaleX / 2);
                float sumPowerUpDistanceY = (powerUp.PowerUpTransform.ScaleY / 2) + (playerTransform.ScaleY / 2);

                if (powerUpDistanceX < sumPowerUpDistanceX && powerUpDistanceY < sumPowerUpDistanceY)
                {
                    GameManager.Instance.LevelController.Score.AddPowerUpPoints(50);
                    GameManager.Instance.LevelController.PowerUp = null;
                    playerController.Invincibility = true;
                    Engine.Debug("Invencibilidad activada");
                    playerController.InvincibilityTimer = 0f;
                }
            }
        }

        public void Update()
        {
            playerController.Update();

            currentAnimation.Update();

            CheckCollision();
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentImage, playerTransform.PosX, playerTransform.PosY);
        }

    }
}
