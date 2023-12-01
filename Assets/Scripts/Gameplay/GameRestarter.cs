using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestarter : MonoBehaviour
{
    [SerializeField]
    private Sounds _sounds;
    [SerializeField]
    private Pauser _pauser;
    [SerializeField]
    private Collector _collector;
    [SerializeField]
    private GameObject _gameOverWindow;
    
    public void FinishGame()
    {
        _pauser.Pause();
        _sounds.Pause();
        _gameOverWindow.SetActive(true);

        if(!PlayerPrefs.HasKey(DataKeys.BestScore) || PlayerPrefs.GetInt(DataKeys.BestScore) < _collector.CollectedCount)
        {
            PlayerPrefs.SetInt(DataKeys.BestScore, _collector.CollectedCount);
        }
    }

    public void Restart()
    {
        _pauser.Unpause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}