using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Spawner
{
    public class SpawnGenerator : MonoBehaviour
    {
        private float spawnLimit = 15;

        [SerializeField] private GameObject _sphere;
        private GameObject[] _spawnPoints;

        private readonly System.Random _rnd = new System.Random();
        private WaitForSeconds _frequency = new WaitForSeconds(2f);

        private void Start()
        {
            _spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
            StartCoroutine(SpawnObjects());
        }

        private IEnumerator SpawnObjects()
        {
            for (int i = 0; i < spawnLimit; i++)
            {
                int randomPosition = _rnd.Next(0, _spawnPoints.Length);
                Debug.Log($"Log: Current iteration {i}, spawn position {randomPosition}");

                Instantiate(_sphere, _spawnPoints[randomPosition].transform.position, Quaternion.identity);

                yield return _frequency;
            }
        }
    } 
}
