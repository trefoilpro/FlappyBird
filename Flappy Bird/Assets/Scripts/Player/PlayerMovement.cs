using System;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        private GameObject tutorial;
        
        [SerializeField] private float strength = 5f;

        private Rigidbody2D playerRigidbody2D;

        private void Awake()
        {
            playerRigidbody2D = GetComponent<Rigidbody2D>();
            playerRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

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
            playerRigidbody2D.velocity = Vector2.up * strength;
        }
    
        private void Movement()
        {
            transform.eulerAngles = new Vector3(0, 0, playerRigidbody2D.velocity.y * 3f);
        }
   
        private void OnEnable()
        {
            playerRigidbody2D.constraints = RigidbodyConstraints2D.None;

            playerRigidbody2D.velocity = Vector2.zero;
        
            Vector3 newPos = transform.position;
            newPos.y = 0f;
            transform.position = newPos;
        }
    }
}
