using System;
using UnityEngine;
using UnityEngine.Events;

#pragma warning disable CS0619
namespace AlarmSpace 
{
    public class DoorArea : MonoBehaviour
    {
        

        [SerializeField] private UnityEvent _reached;

        private void Start()
        {
            Signalisation.IsScriptActivated = gameObject.GetComponent<Signalisation>();
        }
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag("Player") && Signalisation.IsPlaying == false)
            {
                Signalisation.IsScriptActivated.enabled = true;
                _reached?.Invoke();
            }
        }
    }
}
