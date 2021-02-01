using System;
using UnityEngine;
using PersonController;

namespace PersonController
{
    [SerializeField]
    public class MouseLook : MonoBehaviour
    {
        public float MouseSensitivity = 5f;

        public float MouseX = 0f;
        public float MouseY = 0f;

        public float MaxX = 89.9f;
        public float MinX = -90f;

        private Quaternion _characterTargetRot;
        private Quaternion _cameraTargetRot;

        public void Init(Transform character, Transform camera)
        {
            _characterTargetRot = character.localRotation;
            _cameraTargetRot = camera.localRotation;
        }
        public void LookRotation(Transform character, Transform camera)
        {
            MouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
            MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

            _characterTargetRot *= Quaternion.Euler(0f, MouseX, 0f);
            _cameraTargetRot *= Quaternion.Euler(-MouseY, 0f, 0f);

            _cameraTargetRot = ClampRotationAroundXAxis(_cameraTargetRot);

            character.localRotation = _characterTargetRot;
            camera.localRotation = _cameraTargetRot;
        }
        public void CursorStateLock()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private Quaternion ClampRotationAroundXAxis(Quaternion quater)
        {
            quater.x /= quater.w;
            quater.y /= quater.w;
            quater.z /= quater.w;
            quater.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(quater.x);

            angleX = Mathf.Clamp(angleX, MinX, MaxX);

            quater.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

            return quater;
        }
    }
}