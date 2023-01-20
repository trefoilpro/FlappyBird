using UnityEngine;

public class PipeRiding : MonoBehaviour
{
    private float speedOfPipeRiding = 1f;
    
    private void Update()
    {
        if (transform.position.y > 1)
        {
            speedOfPipeRiding = -speedOfPipeRiding;
            transform.localPosition += transform.up * speedOfPipeRiding * 5f * Time.deltaTime;
        }

        if (transform.position.y < -1)
        {
            speedOfPipeRiding = -speedOfPipeRiding;
            transform.localPosition += transform.up * speedOfPipeRiding * 5f * Time.deltaTime;
        }
        
        transform.localPosition += transform.up * speedOfPipeRiding * Time.deltaTime;
    }
}
