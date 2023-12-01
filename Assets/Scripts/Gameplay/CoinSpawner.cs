using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private float _boundX;
    [SerializeField]
    private float _spawnIntervalMin;
    [SerializeField]
    private float _spawnIntervalMax;
    [SerializeField]
    private List<GameObject> _prefabs;

    private void Start()
    {
        StartCoroutine(SpawnCollectables());
    }

    private IEnumerator SpawnCollectables()
    {
        while(true)
        {
            var position = new Vector2(Random.Range(-_boundX, _boundX), transform.position.y);
            var prefab = _prefabs[Random.Range(0, _prefabs.Count)];
            Instantiate(prefab, position, Quaternion.identity);
        
            yield return new WaitForSeconds(Random.Range(_spawnIntervalMin, _spawnIntervalMax));
        }
    }
}