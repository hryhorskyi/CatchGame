using TMPro;
using UnityEngine;

public class BestScoreText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    private void Start()
    {
        if(PlayerPrefs.HasKey(DataKeys.BestScore))
        {
            _text.text = $"Best score: {PlayerPrefs.GetInt(DataKeys.BestScore)}";
        }
    }
}