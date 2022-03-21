using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BestScore : MonoBehaviour
{
    private Text _bestScore;

    private void Start()
    {
        _bestScore = GetComponent<Text>();

        int bestScore = PlayerPrefs.GetInt("BestScore");
        _bestScore.text = "Best Score: " + bestScore;
    }
}
