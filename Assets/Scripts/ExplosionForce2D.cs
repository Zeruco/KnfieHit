using UnityEngine;

public static class ExplosionForce2D
{
    public static void AddExplosionForce2D(Rigidbody2D rigidbody, Transform exploder, float pushForce)
    {
        Vector2 dir = rigidbody.transform.position - exploder.position;
        float wearoff = 1 - (dir.magnitude / pushForce);

        rigidbody.AddForce(dir.normalized * pushForce * wearoff, ForceMode2D.Impulse);
    }
}
