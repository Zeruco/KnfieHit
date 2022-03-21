using UnityEngine;
using UnityEngine.UI;
public class AppleCountText : MonoBehaviour
{
    public Text AppleCount { get; private set; }

    private void Start()
    {
        int applesCount = PlayerPrefs.GetInt("Apples");
        AppleCount = GetComponent<Text>();
        AppleCount.text = applesCount.ToString();
    }
}
