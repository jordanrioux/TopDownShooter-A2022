using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDownShooter.Units.Players
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Player Properties")] 
        [SerializeField] private Vector2 velocity;
        [SerializeField] private Rigidbody2D body;

        private Vector2 _movement;
        
        public void OnMovement(InputValue value)
        {
            _movement = value.Get<Vector2>();
        }

        private void FixedUpdate()
        {
            MoveCharacter();
        }
        
        private void MoveCharacter()
        {
            var movement = _movement * velocity * Time.deltaTime;
            body.MovePosition(body.position + movement);
        }
    }
}
