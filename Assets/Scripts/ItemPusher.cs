using UnityEngine;

[RequireComponent(typeof(Target))]
public abstract class ItemPusher : MonoBehaviour
{
    [SerializeField] protected float _pushForce;

    private Target _target;

    private void Awake()
    {
        _target = GetComponent<Target>();
    }

    private void OnEnable()
    {
        _target.Filled += OnTargetFilled;
    }

    private void OnDisable()
    {
        _target.Filled -= OnTargetFilled;
    }

    protected abstract void OnTargetFilled();
}
