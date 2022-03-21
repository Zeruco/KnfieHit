using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShopItem : MonoBehaviour
{
    [SerializeField] private KnifeSkin _knifeSkin;
    [SerializeField] private Sprite _buyied;
    [SerializeField] private Sprite _selected;

    private Button _selectSkinButton;

    public event UnityAction Selected;

    private void Start()
    {
        _selectSkinButton = GetComponent<Button>();
        _selectSkinButton.interactable = false;

        LoadSkin();
    }

    public void LoadSkin()
    {
        int selectedSkin = PlayerPrefs.GetInt("SkinIndex");
        
        Sprite buttonImage = _selectSkinButton.GetComponent<Image>().sprite;

        if (_knifeSkin.IsBuyied == true && selectedSkin != _knifeSkin.Id)
        {
            _selectSkinButton.GetComponent<Image>().sprite = _buyied;
            _selectSkinButton.interactable = true;
        }
        if (selectedSkin == _knifeSkin.Id)
        {
            _selectSkinButton.GetComponent<Image>().sprite = _selected;
        }
    }

    public void OnClickSelect()
    {
        _knifeSkin.Select();
        Selected?.Invoke();
    }
}
