using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    private Collector _collector;
    [SerializeField]
    private TextMeshProUGUI _text;

    private void Start()
    {
        _collector.Collected += UpdateCounter;
    }

    private void UpdateCounter()
    {
        _text.text = $"Score: {_collector.CollectedCount}";
    }
}