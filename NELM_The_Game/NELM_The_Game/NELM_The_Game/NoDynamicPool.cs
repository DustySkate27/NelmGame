using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class NonDynamicPool
    {
        private List<Enemy> enemyAvailable = new List<Enemy>(); //Se crea una lista de enemigos disponibles
        private List <Enemy> enemyInUse = new List<Enemy>(); //Se crea una lista de enemigos en uso.
        
        public NonDynamicPool(int quantity) //Se define una cantidad de enemigos fija, la cual se usará en bucle.
        {
            for (int i = 0; i < quantity; i++)
            {
                Enemy enemy = new Enemy(0,0,0,0); //Se los spawnea a todos en 0
                enemyAvailable.Add(enemy); // Y se los añade a la lista de disponibles
            }
        }

        public Enemy GetEnemy(float posX, float posY, float speedX, float speedY) //Se llama a un enemigo de la lista, con las referencias necesarias para reposicionarlo.
        {
            Enemy enemy = null; //Se anula al enemigo, para tener una "molde" de variable vacío disponible.

            if (enemyAvailable.Count > 0) //Si la cantidad de enemigos disponibles es mayor a 0
            {
                enemy = enemyAvailable[0]; //Se le asigna al "molde vacío" un enemigo de la lista.
                enemy.EnemyTransform.PosX = posX; //Se le cambia su posición en X
                enemy.EnemyTransform.PosY = posY; //Se le cambia su posición en Y
                enemy.EnemyBehaviour.speedX = speedX; //Se le cambia su velocidad en X
                enemy.EnemyBehaviour.speedY = speedY; //Se le cambia su velocidad en Y 
                enemyAvailable.RemoveAt(0); //Saca de la lista de disponibles al enemigo.
                enemyInUse.Add(enemy); //Lo mete en la lista de enemigos en uso.
            }
            return enemy; //Devuelve al enemigo.
        }

        public void RecycleEnemy(Enemy enemy) //Recicla a los enemigos que estan fuera de pantalla y los reinserta en la lista de disponibilidad.
        {
            enemyInUse.Remove(enemy);
            enemyAvailable.Add(enemy);
        }

    }
}
