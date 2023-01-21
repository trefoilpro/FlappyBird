using UnityEngine;

namespace Pipes
{
    public class PipesMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
    
        private float leftEdge;

        private void Start()
        {
            if (Camera.main != null) 
                leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 5f;
        }

        private void Update()
        {
            transform.position += Vector3.left * (speed * Time.deltaTime);
        
            if (transform.position.x < leftEdge)
            {
                Destroy(gameObject);    
            }
        }
    }
}
