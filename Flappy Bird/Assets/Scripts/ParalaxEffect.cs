using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    [SerializeField] private float _animationSpeed = 1f;
    
    private MeshRenderer _paralaxEffectMeshRenderer;

    private void Awake()
    {
        _paralaxEffectMeshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        _paralaxEffectMeshRenderer.material.mainTextureOffset += new Vector2(_animationSpeed * Time.deltaTime, 0);
    }
}
