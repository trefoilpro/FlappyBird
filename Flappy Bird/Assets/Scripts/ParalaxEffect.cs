using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    [SerializeField] private float animationSpeed = 1f;
    
    private MeshRenderer paralaxEffectMeshRenderer;

    private void Awake()
    {
        paralaxEffectMeshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        paralaxEffectMeshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
