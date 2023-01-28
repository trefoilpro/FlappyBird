using UnityEngine;

namespace Pipes
{
    public class PipeRiding : MonoBehaviour
    {
        private float _speedOfPipeRiding = 1f;
    
        private void Update()
        {
            if (transform.position.y > 1)
            {
                _speedOfPipeRiding = -_speedOfPipeRiding;
                transform.localPosition += transform.up * (_speedOfPipeRiding * 5f * Time.deltaTime);
            }

            if (transform.position.y < -1)
            {
                _speedOfPipeRiding = -_speedOfPipeRiding;
                transform.localPosition += transform.up * (_speedOfPipeRiding * 5f * Time.deltaTime);
            }
        
            transform.localPosition += transform.up * (_speedOfPipeRiding * Time.deltaTime);
        }
    }
}
