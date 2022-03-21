using UnityEngine;

public class KnifePusher : ItemPusher
{
    [SerializeField] private float _gravityScale;

    protected override void OnTargetFilled()
    {
        Knife[] kinfes = GetComponentsInChildren<Knife>();

        foreach (var knife in kinfes)
        {
            knife.Rigidbody.gravityScale = _gravityScale;
            knife.Rigidbody.bodyType = RigidbodyType2D.Dynamic;
            knife.Rigidbody.freezeRotation = false;

            ExplosionForce2D.AddExplosionForce2D(knife.Rigidbody, transform, _pushForce);
        }
    }
}
