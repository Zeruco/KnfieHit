using UnityEngine;

public class ShopItemUpdater : MonoBehaviour
{
    [SerializeField] private SkinShop _skinShop;
    private ShopItem[] _shopItems;

    private void Awake()
    {
        _shopItems = GetComponentsInChildren<ShopItem>();
    }

    private void OnEnable()
    {
        _skinShop.SkinBuyied += OnSkinBuiyed;

        foreach(var shopItem in _shopItems)
        {
            shopItem.Selected += OnSkinBuiyed;
        }
    }

    private void OnDisable()
    {
        _skinShop.SkinBuyied -= OnSkinBuiyed;

        foreach(var shopItem in _shopItems)
        {
            shopItem.Selected -= OnSkinBuiyed;
        }
    }

    private void OnSkinBuiyed()
    {
        foreach (var shopItem in _shopItems)
        {
            shopItem.LoadSkin();
        }
    }
}
