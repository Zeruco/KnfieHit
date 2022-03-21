using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KnifeThrower _knifeThrower;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _knifeThrower.Throw();
        }
    }
}
