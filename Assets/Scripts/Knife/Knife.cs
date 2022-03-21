using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(SpriteRenderer))]
public class Knife : MonoBehaviour
{
    [SerializeField] private float _knockbackForce;
    [SerializeField] private ParticleSystem _hitEffect;

    private SkinHolder _skinHolder;
    private SpriteRenderer _spriteRenderer;

    public Rigidbody2D Rigidbody { get; private set; }
    public Collider2D Collider { get; private set; }

    public event UnityAction Failed;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();

        _skinHolder = FindObjectOfType<SkinHolder>();
        _spriteRenderer.sprite = _skinHolder.GetSkinSprite();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Knife knife))
        {
            Rigidbody.velocity = Vector2.zero;
            Rigidbody.AddForce(Vector2.down * _knockbackForce, ForceMode2D.Impulse);
            Failed?.Invoke();
        }
    }

    public void GenerateHitEffect()
    {
        var hitEffect = Instantiate(_hitEffect, transform.position, _hitEffect.transform.rotation);
        hitEffect.Play();
    }
}
