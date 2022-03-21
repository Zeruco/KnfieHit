using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;
    [SerializeField] private AppleSpawnPoint[] _appleSpawnPoints;
    [SerializeField] private KnifeSpawnPoint[] _knifeSpawnPoints;

    private Stage _stage;
    private KnifeHolder _knifeHolder;
    private TargetSegment[] _segments;

    public event UnityAction Filled;

    public AppleSpawnPoint[] AppleSpawnPoints => _appleSpawnPoints;
    public KnifeSpawnPoint[] KnifeSpawnPoints => _knifeSpawnPoints;

    private void Awake()
    {
        _stage = FindObjectOfType<Stage>();
        _knifeHolder = FindObjectOfType<KnifeHolder>();
        _segments = GetComponentsInChildren<TargetSegment>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Knife knife))
        {
            FixateKnife(knife);

            if (_knifeHolder.Count <= 0)
            {
                Explode();
            }
        }
    }

    private void FixateKnife(Knife knife)
    {
        knife.Collider.isTrigger = false;
        knife.transform.parent = transform;
        knife.Rigidbody.velocity = Vector2.zero;
        knife.Rigidbody.bodyType = RigidbodyType2D.Static;
        knife.transform.position = new Vector3(knife.transform.position.x, knife.transform.position.y, transform.position.z);
        knife.GenerateHitEffect();
    }

    private void Explode()
    {
        StopCoroutine("Rotate");

        foreach (var segment in _segments)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius);
        }

        TargetFilled();
    }

    private void TargetFilled()
    {
        Collider2D collider = GetComponent<Collider2D>();
        Destroy(collider);

        Invoke("DestroyTarget", 1f);

        Filled?.Invoke();
    }

    private void DestroyTarget()
    {
        _stage.CreateNewStage();
        Destroy(gameObject);
    }
}
