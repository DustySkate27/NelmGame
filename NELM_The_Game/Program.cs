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

        static void Main(string[] args)
        {
            Time.Initialize();

            Engine.Initialize();

            GameManager.Instance.Initialize();
           

            while (true)
            {
                Time.Update();

                GameManager.Instance.Update();

                GameManager.Instance.Render();

            }
        }

    }
}