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

        private SignalisationObject[] _SignalisationObject;

        public static bool IsPlaying = false;

        private List<Animator> _listAnimator = new List<Animator>();

        private WaitForFixedUpdate _UpdatingData;
        private Coroutine _coroutine;

        private void Start()
        {
            _SignalisationObject = FindObjectsOfType<SignalisationObject>();

            GetComponent<Signalisation>().enabled = false;

            foreach (SignalisationObject item in _SignalisationObject)
            {
                _listAnimator.Add(item.gameObject.GetComponent<Animator>());
            }
            foreach (Animator item in _listAnimator)
            {
                item.enabled = false;
            }
        }
        
        public void Play()
        {
            _AudioSource.Play();
            IsPlaying = true;
            gameObject.GetComponent<Signalisation>().enabled = true;

            _coroutine = StartCoroutine(CheckDistance());

            foreach (Animator item in _listAnimator)
            {
                item.enabled = true;
            }
        }

        public IEnumerator CheckDistance()
        {
            while (Vector3.Distance(_Player.transform.position, transform.position) < 20)
            {
                yield return _UpdatingData;
            }

            _AudioSource.Stop();
            gameObject.GetComponent<Signalisation>().enabled = false;
            IsPlaying = false;

            DeactivatedAnimations();
            StopCoroutine(_coroutine);
        }
        public void DeactivatedAnimations()
        {
            foreach (Animator item in _listAnimator)
            {
                item.WriteDefaultValues();
                item.enabled = false;
            }
        }
    }
}
