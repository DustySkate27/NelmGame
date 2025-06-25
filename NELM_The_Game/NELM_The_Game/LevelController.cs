using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class LevelController
    {
        private Image background = Engine.LoadImage("assets/background.png");
        private NonDynamicPool nonDynamicPool = new NonDynamicPool(10);

        private Player player1;
        private Score score;
 
        private IPowerUp power;  
        private float powerUpCooldown;
        private Random randomPower = new Random();
        private int powerSelected;


        Enemy enemyX;
        Enemy enemyY;
        private List<Enemy> enemyList = new List<Enemy>();
        private Random randomEnemyPos = new Random();
        private float enemyCD = 1f;
        private float timeSinceLastEnemy = 0f;
        private int enemySpawnOffScreen = -64;
        private float speed = 5;

        public NonDynamicPool NonDynamical => nonDynamicPool;

        public List<Enemy> EnemyList => enemyList;
        
        public Player Player1
        {
            get => player1;
            set => player1 = value;
        }

        public Score Score
        {
            get => score;
            set => score = value;
        }


        public IPowerUp Power => power;

        public void Update()
        {
            player1.Update();

            for (int i = 0; i < enemyList.Count; i++)  
            {
                enemyList[i].Update();
            }

            if (power != null)
            {
                power.Update();
            }
            
            score.Update();

            EnemySpawner();  
            PowerUpSpawner();  
            WinCondition(); 

        }

        public void Render() 
        {
            Engine.Clear();
            Engine.Draw(background, 0, 0); 
            score.Render(); 
            player1.Renderer.Render();  

            if (power != null)
            {
                GameObject powerUp = power as GameObject;
                powerUp.Renderer.Render(); 
            }

            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Renderer.Render(); 
            }

            Engine.Show();
        }

        private void WinCondition()
        {
            if (score.ScoreQuantity >= 500)
            {
                GameManager.Instance.gameStage = GameState.Win;
            }
        }

        public bool WinCheck(int amount)
        {
            if (amount >= 500)
            {
                return true;
            }
            else
                return false;
        }

        private void EnemySpawner() 
        {
            
            int[] enemyPosY = { 72, 212, 352, 492, 632 }; 
            int[] enemyPosX = { 110, 295, 480, 665, 850 }; 

            timeSinceLastEnemy += Time.DeltaTime;

            if (timeSinceLastEnemy >= enemyCD)  
            {
                int randomIndexY = randomEnemyPos.Next(enemyPosY.Length); 
                int randomY = enemyPosY[randomIndexY]; 

                
                enemyX = nonDynamicPool.GetEnemy(enemySpawnOffScreen, randomY, speed, 0);  
                enemyList.Add(enemyX);

                int randomIndexX = randomEnemyPos.Next(enemyPosX.Length); 
                int randomX = enemyPosX[randomIndexX];  

                enemyY = nonDynamicPool.GetEnemy(randomX, enemySpawnOffScreen, 0, speed);  
                enemyList.Add(enemyY);

                timeSinceLastEnemy = 0f;

            }

        }

        
        private void PowerUpSpawner()  
        {
            int[] powerArray = { 0, 1 }; 
            int[] powerUpPosX = { 128, 312, 498, 683, 868 };  
            int[] powerUpPosY = { 90, 230, 370, 510, 650 };  

            powerUpCooldown += Time.DeltaTime;

            if (power == null && powerUpCooldown > 10) 
            {
                int randomIndexY = randomEnemyPos.Next(powerUpPosY.Length);  
                int randomY = powerUpPosY[randomIndexY];  

                int randomIndexX = randomEnemyPos.Next(powerUpPosX.Length);  
                int randomX = powerUpPosX[randomIndexX]; 

                int randomIndexPower = randomPower.Next(powerArray.Length);  
                powerSelected = powerArray[randomIndexPower];  

                if (powerSelected == 0) 
                {
                    power = PowerUpFactory.CreatePowerUp(randomX, randomY, PowerUpFactory.Powers.Invincibility);  
                    power.OnSpecialGain += () => power = null;  
                    power.OnSpecialGain += () => player1.PlayerController.Invincibility = true;  
                    power.OnSpecialGain += () => player1.PlayerController.InvincibilityTimer = 0f;  
                }

                if (powerSelected == 1)
                {
                    power = PowerUpFactory.CreatePowerUp(randomX, randomY, PowerUpFactory.Powers.SuperSpeed);   
                    power.OnSpecialGain += () => power = null;  
                    power.OnSpecialGain += () => player1.PlayerController.SuperSpeed = true; 
                    power.OnSpecialGain += () => player1.PlayerController.SuperSpeedTimer = 0f;    
                     
                }



                powerUpCooldown = 0;  
            }

            if (power != null)  
            {
                power.Update();
            }
        }

        public void Initialize()  
        {
            player1 = new Player();
            player1.PlayerController.Invincibility = false;  
            player1.PlayerController.InvincibilityTimer = 0f;  

            score = new Score();
            power = null;  
            powerUpCooldown = 0;  
        }
    }
}
