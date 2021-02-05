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

        private Transform[] _spawnPoints;

        private WaitForSeconds _frequency = new WaitForSeconds(2f);

        private void Start()
        {
            _spawnPoints = new Transform[transform.childCount];

            for (int i = 0; i < transform.childCount; i++)
            {
                _spawnPoints[i] = transform.GetChild(i);
            }

            StartCoroutine(SpawnObjects());
        }

        private IEnumerator SpawnObjects()
        {
            for (int i = 0; i < spawnLimit; i++)
            {
                int randomPosition = Random.Range(0, _spawnPoints.Length);

                Instantiate(_sphere, _spawnPoints[randomPosition].transform.position, Quaternion.identity);

                yield return _frequency;
            }
        }
    } 
}
