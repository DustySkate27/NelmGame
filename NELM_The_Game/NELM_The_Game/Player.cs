using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{

    public class Player : GameObject, IUpdatable
    {
        private PlayerController playerController;
        private LevelController levelController;
        private Collider collider;

        private int ogPosX = 480;
        private int ogPosY = 352;

        private int scale = 64;
        private bool extraPointsAvailable = false;

        public bool ExtraPointsAvailable
        {
            set => extraPointsAvailable = value;
        }

        public PlayerController PlayerController
        {
            get => playerController;
        }

        public Player()
        {
            float positionX = ogPosX;
            float positionY = ogPosY;
            transform = new Transform(positionX, positionY, scale, scale); 
            renderer = new Renderer(transform, "player/player_idle/player_idle", 3, 0.1f, true);  
            collider = new Collider(transform);
            playerController = new PlayerController(transform);  
            levelController = GameManager.Instance.LevelController;
        }

        public void Update()
        {
            playerController.Update();

            renderer.AnimationUpdate();  

            for (int i = 0; i < levelController.EnemyList.Count; i++)
            {
                Enemy enemy = levelController.EnemyList[i];

                if (collider.CheckCollision(enemy.EnemyTransform) && !playerController.Invincibility)
                {
                    Death();
                }
                if (collider.CheckCollision(enemy.EnemyTransform) && playerController.Invincibility && extraPointsAvailable)
                {
                    levelController.Score.ScoreQuantity += 50;
                    extraPointsAvailable = false;
                }
            }

            if (levelController.Power != null)
            {
                GameObject powerUp = levelController.Power as GameObject;
                if (collider.CheckCollision(powerUp.Transform))
                {
                    levelController.Power.SpecialPower();
                }
            }
        }



        public bool extraPointChecker(bool enters)
        {
            if (enters)
                return extraPointsAvailable = true;
            else
                return false;
        }

        public void Death()
        {
            GameManager.Instance.gameStage = GameState.Lose;
        }


    }
}
