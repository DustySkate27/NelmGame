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
        static private float deltaTime;
        static private float timeLastFrame;
        static private DateTime initialTime;
        static public float DeltaTime => deltaTime;

        static void Main(string[] args)
        {
            initialTime = DateTime.Now;

            Engine.Initialize();
            GameManager.Instance.Initialize();
           

            while (true)
            {
                float currentTime = (float)(DateTime.Now - initialTime).TotalSeconds;
                deltaTime = currentTime - timeLastFrame;
                timeLastFrame = currentTime;

                GameManager.Instance.Update();

                GameManager.Instance.Render();

            }
        }

    }
}