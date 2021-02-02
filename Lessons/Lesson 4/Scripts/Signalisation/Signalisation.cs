using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0619
namespace AlarmSpace
{
    public class Signalisation : MonoBehaviour
    {
        [HideInInspector] public static Signalisation IsScriptActivated { get; set; }

        [SerializeField] private AudioSource _AudioSource;

        [SerializeField] private GameObject _Player;

        private GameObject[] _SignObjects;

        public static bool IsPlaying = false;

        private List<Animator> _listAnimator = new List<Animator>();

        private void Start()
        {
            _SignObjects = GameObject.FindGameObjectsWithTag("SignalisationBlock");
            IsScriptActivated.enabled = false;

            foreach (GameObject item in _SignObjects)
            {
                _listAnimator.Add(item.gameObject.GetComponent<Animator>());
            }
            foreach (Animator item in _listAnimator)
            {
                item.enabled = false;
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

            foreach (Animator item in _listAnimator)
            {
                item.enabled = true;
            }
        }
        
        public void DeactivationDistance()
        {
            if (Vector3.Distance(_Player.transform.position, transform.position) > 20 && IsPlaying == true)
            {
                _AudioSource.Stop();
                IsScriptActivated.enabled = false;
                IsPlaying = false;

                foreach (Animator item in _listAnimator)
                {
                    item.WriteDefaultValues();
                    item.enabled = false;
                }
            }
        }
    }
}
