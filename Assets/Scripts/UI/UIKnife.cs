using UnityEngine;

public class UIKnife : MonoBehaviour
{
    [SerializeField] private SkinHolder _skinHolder;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _spriteRenderer.sprite = _skinHolder.GetSkinSprite();
    }
}
