using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeHolder : MonoBehaviour
{
    [SerializeField] private int _minKnifeCount;
    [SerializeField] private int _maxKnifeCount;
    [SerializeField] private KnifeThrower _knifeThrower;
    [SerializeField] private Image _filledKnifeImage;
    [SerializeField] private Image _emptyKnifeImage;

    private List<Image> _knifes = new List<Image>();
    private int _count;

    public int Count => _count;

    private void OnEnable()
    {
        _knifeThrower.KnifeThrowed += OnKnifeThrowed;
    }

    private void OnDisable()
    {
        _knifeThrower.KnifeThrowed -= OnKnifeThrowed;
    }

    private void OnKnifeThrowed()
    {
        _knifes[_count - 1].sprite = _emptyKnifeImage.sprite;
        _count--;
    }

    public void Reload()
    {
        _count = Random.Range(_minKnifeCount, _maxKnifeCount);
        LoadKnifes();
    }

    private void LoadKnifes()
    {
        ClearContent();

        for (int i = 0; i < _count; i++)
        {
            Image knife = Instantiate(_filledKnifeImage, transform.position, _filledKnifeImage.transform.rotation, transform);
            _knifes.Add(knife);
        }
    }

    private void ClearContent()
    {
        foreach (var knife in _knifes)
        {
            Destroy(knife.gameObject);
        }
        _knifes.Clear();
    }
}
