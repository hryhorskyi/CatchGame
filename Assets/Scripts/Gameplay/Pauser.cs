using TMPro;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    [SerializeField]
    private PlayerMove _playerMove;
    
    public void Pause()
    {
        Time.timeScale = 0;
        _playerMove.Pause();
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        _playerMove.Unpause();
    }
}