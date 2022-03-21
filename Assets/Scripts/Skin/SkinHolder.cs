using UnityEngine;

public class SkinHolder : MonoBehaviour
{
    [SerializeField] private KnifeSkin[] _skins;
    [SerializeField] private Sprite _standartSkin;

    public KnifeSkin[] Skins => _skins;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public Sprite GetSkinSprite()
    {
        int skinId = PlayerPrefs.GetInt("SkinIndex");

        foreach (var skin in _skins)
        {
            if (skin.Id == skinId)
            {
                return skin.Sprite;
            }
        }

        return _standartSkin;
    }
}
