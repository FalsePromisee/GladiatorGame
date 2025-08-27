using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _healthPoints;
    
    [SerializeField] private Transform _coinAndHealthContainer;

    private float _timeToSpawnCoin = 5f;
    private float _repeatRateTime = 10f;
    
    
    void Start()
    {
        InvokeRepeating("CoinSpawner", _timeToSpawnCoin, _repeatRateTime);
    }

    void Update()
    {
        
    }

    private void CoinSpawner()
    {
        float randomXpoint = Random.Range(70, -70);
        float randomZpoint = Random.Range(70, -70);
        
        Instantiate(_coin, new Vector3(randomXpoint, 1, randomZpoint), Quaternion.identity, _coinAndHealthContainer);
        
    }

    private void HealthPointSpawner()
    {
        float randomXpoint = Random.Range(50, -50);
        float randomZpoint = Random.Range(50, -50);
        
        Instantiate(_healthPoints, new Vector3(randomXpoint, 1, randomZpoint), Quaternion.identity, _coinAndHealthContainer);

    }
    
}
