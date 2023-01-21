using Managers;
using UnityEngine;

namespace Player
{
    public class CheckCollision : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                _gameManager.GameOver();
            }

            if (other.gameObject.CompareTag("Scoring"))
            {
                _gameManager.InceaseScore();
            }
        }
    }
}
