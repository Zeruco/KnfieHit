using UnityEngine;
using UnityEngine.Events;

public class KnifeThrower : MonoBehaviour
{
    [SerializeField] private float _throwForce;
    [SerializeField] private float _throwDelay;
    [SerializeField] private KnifeSpawner _knifeSpawner;
    [SerializeField] private KnifeHolder _knifeHolder;
    [SerializeField] private GameObject _failedWindow;

    private float _timeAfterThrow;
    private Knife _throwedKnife;

    public event UnityAction KnifeThrowed;

    private void Awake()
    {
        Vibration.Init();
        _timeAfterThrow = _throwDelay;
    }

    public void Throw()
    {
        if (_timeAfterThrow >= _throwDelay && _knifeHolder.Count > 0)
        {
            _throwedKnife = _knifeSpawner.ReadyKnife;

            TrackingKnife();

            Rigidbody2D knifeRigidbody = _throwedKnife.GetComponent<Rigidbody2D>();
            Collider2D knifeCollider = _throwedKnife.GetComponent<Collider2D>();

            knifeCollider.isTrigger = true;
            knifeRigidbody.AddForce(Vector2.up * _throwForce, ForceMode2D.Impulse);

            _timeAfterThrow = 0;

            KnifeThrowed?.Invoke();
            Vibration.Vibrate(50);
            _knifeSpawner.Spawn();
        }
    }

    private void TrackingKnife()
    {
        _throwedKnife.Failed -= OnFailed;
        _throwedKnife.Failed += OnFailed;
    }

    private void Update()
    {
        _timeAfterThrow += Time.deltaTime;
    }

    private void OnFailed()
    {
        _failedWindow.SetActive(true);
    }
}
