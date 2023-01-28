using UnityEngine;

namespace Pipes
{
    public class PipesMovement : MonoBehaviour
    {
        private float _speed = 5f;
    
        private float _leftEdge;

        private void Start()
        {
            if (Camera.main != null) 
                _leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 5f;
        }

        private void Update()
        {
            transform.position += Vector3.left * (_speed * Time.deltaTime);
        
            if (transform.position.x < _leftEdge)
            {
                Destroy(gameObject);    
            }
        }
    }
}
