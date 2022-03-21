using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Apple : MonoBehaviour
{
    [SerializeField] private AppleSegment[] _appleSegments;
    [SerializeField] private float _pushForce;

    private AppleCountText _applesCountText;
    private Rigidbody2D _rigidbody;

    public Rigidbody2D Rigidbody => _rigidbody;

    private void Start()
    {
        _applesCountText = FindObjectOfType<AppleCountText>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Knife knife))
        {
            Cut();
        }
    }

    private void Cut()
    {
        int appleCount = PlayerPrefs.GetInt("Apples") + 1;
        PlayerPrefs.SetInt("Apples", appleCount);

        _applesCountText.AppleCount.text = appleCount.ToString();

        foreach (var segment in _appleSegments)
        {
            var spawnedSegment = Instantiate(segment, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
