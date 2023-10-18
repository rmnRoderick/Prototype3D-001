using UnityEngine;

    public class KeyboardInput : IInput
    {
        private Vector3 movement;

        public Vector3 GetMovement()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");
            movement = new Vector3(horizontalInput, 0, verticalInput);

            return Time.deltaTime * movement;

        }
    }