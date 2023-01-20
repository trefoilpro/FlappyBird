using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    private MeshRenderer paralaxEffectMeshRenderer;
    [SerializeField] private float animationSpeed = 1f;

    private void Awake()
    {
        paralaxEffectMeshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        paralaxEffectMeshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
