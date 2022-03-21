using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinShop : MonoBehaviour
{
    [SerializeField] private AppleKnifeSkin[] _appleKnifeSkins;
    [SerializeField] private BossKnifeSkin[] _bossKnifeSkins;
    [SerializeField] private int _price;
    [SerializeField] private Text _applesCountText;

    public event UnityAction SkinBuyied;

    public void GetRandomKnife()
    {
        if (GetEnableSkins(_appleKnifeSkins) > 0)
        {
            TryGetRandomSkin(_appleKnifeSkins);
        }
    }

    private int GetEnableSkins(KnifeSkin[] skins)
    {
        int enableSkins = 0;

        for (int i = 0; i < skins.Length; i++)
        {
            if (skins[i].IsBuyied == false)
            {
                enableSkins++;
            }
        }

        return enableSkins;
    }

    private void TryGetRandomSkin(KnifeSkin[] skins)
    {
        int apples = PlayerPrefs.GetInt("Apples");

        if (apples < _price)
        {
            return;
        }

        while (true)
        {
            int randomIndex = Random.Range(0, skins.Length);

            if (skins[randomIndex].IsBuyied == false)
            {
                apples -= _price;
                _applesCountText.text = apples.ToString();
                PlayerPrefs.SetInt("Apples", apples);
                skins[randomIndex].Buy();
                skins[randomIndex].Select();

                SkinBuyied?.Invoke();

                return;
            }
        }
    }
}
