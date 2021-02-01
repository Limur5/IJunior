using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0619
namespace AlarmSpace
{
    public class Signalisation : MonoBehaviour
    {
        [SerializeField] private AudioSource _AudioSource;

        [SerializeField] private GameObject _Player;

        private GameObject[] _SignObjects;

        public static bool IsPlaying = false;
        private void Start()
        {
            _SignObjects = GameObject.FindGameObjectsWithTag("SignalisationBlock");

            foreach (GameObject item in _SignObjects)
            {
                item.GetComponent<Animator>().enabled = false;

                DoorArea.IsScriptActivated.enabled = false;
            }
        }

        private void FixedUpdate()
        {
            DeactivationDistance();
        }
        public void Play()
        {
            _AudioSource.Play();
            IsPlaying = true;

            foreach (GameObject item in _SignObjects)
            {
                item.GetComponent<Animator>().enabled = true;
            }
        }
        public void DeactivationDistance()
        {
            if (Vector3.Distance(_Player.transform.position, transform.position) > 20 && IsPlaying == true)
            {
                _AudioSource.Stop();
                DoorArea.IsScriptActivated.enabled = false;
                IsPlaying = false;

                foreach (GameObject item in _SignObjects)
                {
                    item.GetComponent<Animator>().WriteDefaultValues();
                    item.GetComponent<Animator>().enabled = false;
                }
            }
        }
    }
}
