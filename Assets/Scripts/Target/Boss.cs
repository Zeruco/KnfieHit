using UnityEngine;

[RequireComponent(typeof(Target))]
public class Boss : MonoBehaviour
{
    private Target _target;
    private SkinHolder _skinHolder;

    private void Awake()
    {
        _target = GetComponent<Target>();
        _skinHolder = FindObjectOfType<SkinHolder>();
    }

    private void OnEnable()
    {
        _target.Filled += OnTargetFilled;
    }

    private void OnDisable()
    {
        _target.Filled += OnTargetFilled;
    }

    private void OnTargetFilled()
    {
        foreach (var skin in _skinHolder.Skins)
        {
            if (skin is BossKnifeSkin && skin.IsBuyied == false)
            {
                skin.Buy();
                return;
            }
        }
    }
}
