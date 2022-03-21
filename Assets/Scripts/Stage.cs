using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    [SerializeField] private TargetSpawner _targetSpawner;
    [SerializeField] private KnifeHolder _knifeHolder;
    [SerializeField] private Text _stageNumberText;
    [SerializeField] private Target _targetTemplate;
    [SerializeField] private Target _bossTargetTemplate;

    private int _number;

    private void Awake()
    {
        CreateNewStage();
    }

    public void CreateNewStage()
    {
        UpdateUI();
        _knifeHolder.Reload();

        if (_number % 5 == 0)
        {
            _targetSpawner.Spawn(_bossTargetTemplate);
        }
        else
        {
            _targetSpawner.Spawn(_targetTemplate);
        }
    }

    private void UpdateUI()
    {
        _number++;
        _stageNumberText.text = $"Stage: {_number}";
    }
}
