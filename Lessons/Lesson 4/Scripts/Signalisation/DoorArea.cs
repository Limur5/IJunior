using System;
using UnityEngine;
using UnityEngine.Events;

#pragma warning disable CS0619
namespace AlarmSpace 
{
    public class DoorArea : MonoBehaviour
    {
        [SerializeField] private UnityEvent _reached;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Player player) && Signalisation.IsPlaying == false)
            {
                _reached?.Invoke();
            }
        }
    }
}
