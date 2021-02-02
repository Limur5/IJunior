using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawners
{
    public class SpawnGenerator : MonoBehaviour
    {
        private GameObject[] _spawnPoints;

        private float spawnLimit = 0;

        private System.Random rnd = new System.Random();


        private void Start()
        {
            _spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
        }

        private void FixedUpdate()
        {
            while (spawnLimit < 15)
            {
                foreach (GameObject item in _spawnPoints)
                {

                }
            }
        }
    } 
}
