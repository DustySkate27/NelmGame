using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using Tao.Sdl;



namespace MyGame
{

    class Program
    {
        static private Image background = Engine.LoadImage("assets/background.png");

        static private List<Enemy> enemyList = new List<Enemy>();

        static private Player player1;

        static private Random randomEnemyPos = new Random();

        static float deltaTime;
        static float timeLastFrame;
        static DateTime initialTime;

        static private float enemyCD = 5f;
        static private float timeSinceLastEnemy = 0f;

        static public float DeltaTime => deltaTime;

        static public List <Enemy> EnemyList => enemyList;

        static public Player Player1 => player1;


        static void Main(string[] args)
        {
            initialTime = DateTime.Now;

            Engine.Initialize();
            player1 = new Player(400, 400);

            //añadirlos a la lista
            enemyList.Add(new Enemy(0, 210));
            enemyList.Add(new Enemy(0, 350));
            enemyList.Add(new Enemy(0, 490));
            enemyList.Add(new Enemy(0, 630));

            while (true)
            {
                float currentTime = (float)(DateTime.Now - initialTime).TotalSeconds;
                deltaTime = currentTime - timeLastFrame;
                timeLastFrame = currentTime;

                Render();

                Update();

            }
        }
        static void Render()
        {
            Engine.Clear();
            Engine.Draw(background, 0, 0);

            player1.Render();

            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Render();
            }

            Engine.Show();
        }

        static void Update()
        {
            player1.Update();

            for (int i = 0; i < enemyList.Count; i++) 
            { 
                enemyList[i].Update(); 
            }

            timeSinceLastEnemy += deltaTime;

            EnemySpawner();
        }

        static private void EnemySpawner()
        {
            int[] enemyPosX = { 70, 210, 350, 490, 630 };

            if (timeSinceLastEnemy >= enemyCD)
            {
                int randomIndexY = randomEnemyPos.Next(enemyPosX.Length);
                int randomX = enemyPosX[randomIndexY];

                enemyList.Add(new Enemy(0, randomX));
                timeSinceLastEnemy = 0f;
            }
        }

    }
}