using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TargetSegment : MonoBehaviour
{
    public void Bounce(float force, Vector3 centre, float radius)
    {
        if (TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(force, centre, radius);
        }
    }
}
