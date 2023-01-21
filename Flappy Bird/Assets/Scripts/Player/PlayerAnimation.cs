using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Sprite[] sprites;
    
        private SpriteRenderer playerSpriteRenderer;
    
        private int spriteIndex;

        private void Awake()
        {
            playerSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        }

        private void AnimateSprite()
        {
            spriteIndex++;

            if (spriteIndex >= sprites.Length)
            {
                spriteIndex = 0;
            }
        
            playerSpriteRenderer.sprite = sprites[spriteIndex];
        }
    }
}
