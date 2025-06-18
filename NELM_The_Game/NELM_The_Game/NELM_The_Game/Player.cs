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

    public class Player : GameObject //Hereda de GameObject
    {
        private PlayerController playerController;
        private LevelController levelController;
        private Collider collider;

        private int ogPosX = 480;
        private int ogPosY = 352;

        private int scale = 64;

        public PlayerController PlayerController
        {
            get => playerController;
        }

        public Player()
        {
            float positionX = ogPosX;
            float positionY = ogPosY;
            transform = new Transform(positionX, positionY, scale, scale); //Donde aparece
            renderer = new Renderer(transform, "player/player_idle/player_idle", 3, 0.1f, true); //Se llama a el renderer heredado y se le asignan las variables necesarias.
            collider = new Collider(transform);
            playerController = new PlayerController(transform); //Hacia donde se mueve
            levelController = GameManager.Instance.LevelController;

            
        }

        public void Update()
        {
            playerController.Update();

            renderer.AnimationUpdate(); //Se agrega un actualizador del renderer.

            for (int i = 0; i < levelController.EnemyList.Count; i++)
            {
                Enemy enemy = levelController.EnemyList[i];

                if (collider.CheckCollision(enemy.EnemyTransform) && !playerController.Invincibility)
                {
                    Death();
                }
            }

            if (playerController.Invincibility)
            {
                renderer.ChangeAnimation("player/player_power1/player_power0", 3, 0.1f);
                renderer.AnimationUpdate();

            }

            if (playerController.SuperSpeed)
            {
                renderer.ChangeAnimation("player/player_power2/player_power20", 3, 0.1f);
                renderer.AnimationUpdate();

            }

            if (!playerController.Invincibility && !playerController.SuperSpeed)
            {
                {
                    renderer.ChangeAnimation("player/player_idle/player_idle", 3, 0.1f);
                    renderer.AnimationUpdate();

                }
            }
            
        }

        public bool TestGetInvincibility()
        {
            if (playerController.Invincibility)
            {
                return true;
            }
            else
                return false;
            
        }

        public void Death()
        {
            GameManager.Instance.gameStage = GameState.Lose;
            Engine.Debug("CRITICAL HIT");
        }


    }
}
