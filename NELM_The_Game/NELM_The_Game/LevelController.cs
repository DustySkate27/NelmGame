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

        //Variables de PowerUp
        private IPowerUp power; //Se define una variable general para los powerups
        private float powerUpCooldown;
        private Random randomPower = new Random();
        private int powerSelected;

        //Variables de Enemy
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


        public int PowerSelected => powerSelected;

        public IPowerUp Power => power;

        public void Update()
        {
            player1.Update(); //Actualiza al jugador

            for (int i = 0; i < enemyList.Count; i++) //Actualiza a los enemigos
            {
                enemyList[i].Update();
            }

            if (power != null)
            {
                power.Update();
            }
            
            EnemySpawner(); //Spawn enemigos
            PowerUpSpawner(); //Spawn PowerUp
            score.Update(); //Actualiza el puntaje
            WinCondition(); //Chequea si se logra ganar

        }

        public void Render() 
        {
            Engine.Clear();
            Engine.Draw(background, 0, 0); //Dibuja el fondo
            score.Render();//Renderiza el puntaje
            player1.Renderer.Render(); //Renderiza el jugador

            if (power != null)
            {
                GameObject powerupGame = power as GameObject;
                powerupGame.Renderer.Render(); //Si power up "está" en pantalla, lo renderiza
            }

            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Renderer.Render(); //Renderiza a todos los enemigos
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

        private void EnemySpawner() //Spawn de enemigos
        {
            
            int[] enemyPosY = { 72, 212, 352, 492, 632 }; //Posiciones en Y
            int[] enemyPosX = { 110, 295, 480, 665, 850 }; //Posiciones en X

            timeSinceLastEnemy += Time.DeltaTime;

            if (timeSinceLastEnemy >= enemyCD) //Cooldown entre enemigos
            {
                int randomIndexY = randomEnemyPos.Next(enemyPosY.Length); //Selección aleatoria de las posiciones definidas
                int randomY = enemyPosY[randomIndexY]; //Inserta la posicion elegida y devuelve su valor

                
                enemyX = nonDynamicPool.GetEnemy(enemySpawnOffScreen, randomY, speed, 0); //Añade el enemigo a la lista, con su valor en Y insertado
                enemyList.Add(enemyX);

                int randomIndexX = randomEnemyPos.Next(enemyPosX.Length); //Selección aleatoria de las posiciones definidas
                int randomX = enemyPosX[randomIndexX]; //Inserta la posicion elegida y devuelve su valor

                enemyY = nonDynamicPool.GetEnemy(randomX, enemySpawnOffScreen, 0, speed); //Añade el enemigo a la lista, con su valor en Y insertado
                enemyList.Add(enemyY);

                timeSinceLastEnemy = 0f; //reset de cooldown

            }

        }

        
        private void PowerUpSpawner() //Spawn del power up
        {
            int[] powerArray = { 0, 1 }; //Posibles poderes
            int[] powerUpPosX = { 128, 312, 498, 683, 868 }; //Posiciones en X
            int[] powerUpPosY = { 90, 230, 370, 510, 650 }; //Posiciones en Y

            powerUpCooldown += Time.DeltaTime;

            if (power == null && powerUpCooldown > 10) //Si no hay ningun PowerUp en pantalla y pasa el cooldown del PowerUp
            {
                int randomIndexY = randomEnemyPos.Next(powerUpPosY.Length); //Selección aleatoria de las posiciones definidas
                int randomY = powerUpPosY[randomIndexY]; //Inserta la posicion elegida y devuelve su valor

                int randomIndexX = randomEnemyPos.Next(powerUpPosX.Length); //Selección aleatoria de las posiciones definidas
                int randomX = powerUpPosX[randomIndexX]; //Inserta la posicion elegida y devuelve su valor

                int randomIndexPower = randomPower.Next(powerArray.Length); //Selección aleatoria de los posibles poderes.
                powerSelected = powerArray[randomIndexPower]; //Inserta el poder elegido y devuelve su valor.

                if (powerSelected == 0) 
                {
                    power = PowerUpFactory.CreatePowerUp(randomX, randomY, PowerUpFactory.Powers.Invincibility); //Se llama al Factory de PowerUp, que determina el poder que se utilizará.
                    power.OnSpecialGain += () => power = null; //Desaparece el Power Up
                    power.OnSpecialGain += () => player1.PlayerController.Invincibility = true; //Activa la invencibilidad del jugador
                    power.OnSpecialGain += () => player1.PlayerController.InvincibilityTimer = 0f; //Inicia un contador de duración en 0
                    //La interpretación de la suscripción de eventos en este caso es: Se suscribe una función vacía a 'OnSpecialGain' y se la Getea como la línea de código designada.
                }

                if (powerSelected == 1)
                {
                    power = PowerUpFactory.CreatePowerUp(randomX, randomY, PowerUpFactory.Powers.SuperSpeed);  //Se llama al Factory de PowerUp, que determina el poder que se utilizará.
                    power.OnSpecialGain += () => power = null; //Desaparece el Power Up
                    power.OnSpecialGain += () => player1.PlayerController.SuperSpeed = true;//Activa la invencibilidad del jugador
                    power.OnSpecialGain += () => player1.PlayerController.SuperSpeedTimer = 0f;   //Inicia un contador de duración en 0
                    //La interpretación de la suscripción de eventos en este caso es: Se suscribe una función vacía a 'OnSpecialGain' y se la Getea como la línea de código designada.
                }



                powerUpCooldown = 0; //reset de cooldown
            }

            if (power != null) //Si el powerUp existe, lo actualiza
            {
                power.Update();
            }
        }

        public void Initialize() //Inicializador / Reseteador del nivel
        {
            //GC.Collect();
            player1 = new Player(); //Posicion de inicio del player
            player1.PlayerController.Invincibility = false; //Inicio sin invencibilidad
            player1.PlayerController.InvincibilityTimer = 0f; //Y resetea su invencibilidad (Por si acaso)

            score = new Score(); //Crea un puntaje
            power = null; //anula al principio el PowerUp 
            powerUpCooldown = 0; //resetea su cooldown
        }
    }
}
