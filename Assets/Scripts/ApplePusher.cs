using UnityEngine;

public class ApplePusher : ItemPusher
{
    protected override void OnTargetFilled()
    {
        Apple[] apples = GetComponentsInChildren<Apple>();

        foreach (var apple in apples)
        {
            apple.Rigidbody.bodyType = RigidbodyType2D.Dynamic;
            apple.Rigidbody.freezeRotation = false;

            ExplosionForce2D.AddExplosionForce2D(apple.Rigidbody, transform, _pushForce);
        }
    }
}
