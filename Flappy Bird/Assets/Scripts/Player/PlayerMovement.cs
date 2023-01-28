using System;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        private GameObject _tutorial;
        
        [SerializeField] private float _strength = 5f;

        [SerializeField] private Rigidbody2D _playerRigidbody2D;

        private void Update()
        {
            GetInput();
            Movement();
        }

        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Jump();
                _gameManager.tutorial.SetActive(false);
                _gameManager.PlayerNeedTutorial = false;
            }
        }

        private void Jump()
        {
            _playerRigidbody2D.velocity = Vector2.up * _strength;
        }
    
        private void Movement()
        {
            transform.eulerAngles = new Vector3(0, 0, _playerRigidbody2D.velocity.y * 3f);
        }
   
        private void OnEnable()
        {
            _playerRigidbody2D.constraints = RigidbodyConstraints2D.None;

            _playerRigidbody2D.velocity = Vector2.zero;
        
            Vector3 newPos = transform.position;
            newPos.y = 0f;
            transform.position = newPos;
        }
    }
}
