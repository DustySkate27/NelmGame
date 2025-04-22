using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Net.NetworkInformation;
using Tao.Sdl;



namespace MyGame
{

    class Program
    {
        static private Image fondo = Engine.LoadImage("assets/background.png");
        static private Animation animation;

        static private Player player;

        static float deltaTime;
        static float timeLastFrame;
        static DateTime initialTime;

        static public float DeltaTime => deltaTime;

        static void Main(string[] args)
        {
            Engine.Initialize();
            InitializeLevel();
            initialTime = DateTime.Now;

            while (true)
            {
                float currentTime = (float)(DateTime.Now - initialTime).TotalSeconds;
                deltaTime = currentTime - timeLastFrame;
                timeLastFrame = currentTime;
                Update();
                Render();


            }



        }

        static void Update()
        {
            
            player.Update();
        }

        static void InitializeLevel()
        {
            player = new Player(512, 384);
        }


        static void Render()
        {
            Engine.Clear();
            Engine.Draw(fondo, 0, 0);
            player.Render();
            

            Engine.Show();
        }
    }
}