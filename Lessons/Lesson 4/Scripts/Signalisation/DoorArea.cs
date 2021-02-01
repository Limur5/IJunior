using System;
using UnityEngine;
using UnityEngine.Events;

#pragma warning disable CS0619
namespace AlarmSpace 
{
    public class DoorArea : MonoBehaviour
    {
        [HideInInspector] public static Signalisation IsScriptActivated { get; set; }

        [SerializeField] private UnityEvent _reached;

        private void Start()
        {
            IsScriptActivated = gameObject.GetComponent<Signalisation>();
        }
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag("Player") && Signalisation.IsPlaying == false)
            {
                IsScriptActivated.enabled = true;
                _reached?.Invoke();
            }
        }
    }
}
