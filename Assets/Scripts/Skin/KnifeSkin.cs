using UnityEngine;


public abstract class KnifeSkin : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private Sprite _skin;
    [SerializeField] private bool _isBuyied;

    public Sprite Sprite => _skin;
    public bool IsBuyied => _isBuyied;
    public int Id => _id;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Buyied" + _id) == 1)
        {
            _isBuyied = true;
        }
    }

    public void Buy()
    {
        PlayerPrefs.SetInt("Buyied" + _id, 1);
        _isBuyied = true;
    }

    public void Select()
    {
        PlayerPrefs.SetInt("SkinIndex", _id);
    }
}
