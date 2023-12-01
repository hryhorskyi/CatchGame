using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField]
    private Sounds _sounds;
    [SerializeField]
    private GameRestarter _restarter;
    
    public int CollectedCount { get; private set; }
    
    public event Action Collected;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent<Coin>(out var coin))
        {
            CollectedCount++;
            Destroy(coin.gameObject);
            Collected?.Invoke();
            _sounds.PlayCoinSound();
        }

        if(other.gameObject.TryGetComponent<KillingCoin>(out var killingCoin))
        {
            _restarter.FinishGame();
        }
    }
}