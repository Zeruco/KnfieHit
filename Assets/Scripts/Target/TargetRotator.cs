using UnityEngine;
using DG.Tweening;

public class TargetRotator : MonoBehaviour
{
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _rotationCount;

    private Tween _rotator;
    private Target _target;

    private void Awake()
    {
        _target = GetComponent<Target>();
        _rotator = transform.DORotate(new Vector3(0, 0, 360 * _rotationCount), _animationDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental);
    }

    private void OnEnable()
    {
        _target.Filled += OnFilled;
    }

    private void OnDisable()
    {
        _target.Filled -= OnFilled;
    }

    private void OnFilled()
    {
        StopRotation();
    }

    private void StopRotation()
    {
        _rotator.Kill();
    }
}