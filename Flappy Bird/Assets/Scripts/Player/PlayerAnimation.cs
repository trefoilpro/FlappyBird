using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
    
        private SpriteRenderer _playerSpriteRenderer;
    
        private int _spriteIndex;

        private void Awake()
        {
            _playerSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        }

        private void AnimateSprite()
        {
            _spriteIndex++;

            if (_spriteIndex >= _sprites.Length)
            {
                _spriteIndex = 0;
            }
        
            _playerSpriteRenderer.sprite = _sprites[_spriteIndex];
        }
    }
}
