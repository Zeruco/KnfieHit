using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    [SerializeField] private KnifeThrower _knifeThrower;

    private int _bestScore;
    private int _score;
    private Text _scoreText;

    private void Start()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore");
        _scoreText = GetComponent<Text>();
    }

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
        _score++;
        _scoreText.text = _score.ToString();

        if (_score > _bestScore)
        {
            PlayerPrefs.SetInt("BestScore", _score);
        }
    }
}
