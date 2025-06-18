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
            Time.Initialize(); //Inicio de la percepción del tiempo y su almacenamiento. Previo al Engine, de forma que sea milésima 0 de arranque.

            Engine.Initialize(); //Arranque de la ejecución de ventana

            GameManager.Instance.Initialize(); //Inicio de GameManager
           

            while (true)
            {
                Time.Update(); //Actualizador de tiempo

                GameManager.Instance.Update(); // Ejecución del GameManager

                GameManager.Instance.Render(); // Renderizado del GameManager

            }
        }

    }
}