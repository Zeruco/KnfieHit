using System;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    [SerializeField] private Knife _knifeTemplate;
    [SerializeField] private float _positionY;
    [SerializeField] private float _speed;

    private Vector2 _startPosition;
    private float _distanceToAttackTarget;
    private float _startTime;
    private float _movedTime;

    public bool IsReady { get; private set; }
    public Knife ReadyKnife { get; private set; }

    private void Start()
    {
        Time.timeScale = 1;
        _startTime = Time.deltaTime;
        _startPosition = transform.position;
        _distanceToAttackTarget = Math.Abs(transform.position.y + _positionY);

        Spawn();
    }

    public void Spawn()
    {
        IsReady = false;
        _movedTime = 0;

        ReadyKnife = Instantiate(_knifeTemplate, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        _movedTime += Time.deltaTime;
        float distCovered = (_movedTime - _startTime) * _speed;
        float percent = distCovered / _distanceToAttackTarget;

        ReadyKnife.transform.position = Vector2.Lerp(_startPosition, new Vector3(_startPosition.x, _positionY), percent);
        if (percent == 1)
        {
            IsReady = true;
        }
    }
}
