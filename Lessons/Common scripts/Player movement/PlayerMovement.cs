using System;
using UnityEngine;
using PersonController;

namespace PersonController
{
    [SerializeField]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 6f;

        private float moveHorizontal;
        private float moveVertical;

        [SerializeField] private Camera _camera;

        [SerializeField] private MouseLook _mouseLook = new MouseLook();
        

        private Vector3 _movementVector;
        
        private void Start()
        {
            _mouseLook.Init(transform, _camera.transform);
            _mouseLook.CursorStateLock();
        }
        private void FixedUpdate()
        {
            Move();
        }
        private void LateUpdate()
        {
             _mouseLook.LookRotation(transform, _camera.transform);
        }
        private void Move()
        {
            moveHorizontal = Input.GetAxis("Horizontal") * speed;
            moveVertical = Input.GetAxis("Vertical") * speed;

            _movementVector = new Vector3(moveHorizontal, 0f, moveVertical);

            transform.Translate(_movementVector * Time.fixedDeltaTime);
        }
    }
}
