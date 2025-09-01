using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _healthPoints;
    
    [SerializeField] private Transform _coinAndHealthContainer;

    public static int EnemyCount { get; private set; } = 0;
    public static int MaxEnemyCount { get; private set; } = 20;

    private float _timeToSpawnCoin = 5f;
    private float _repeatRateTimeCoin = 10f;
    
    private float _timeToSpawnHealthPoints = 60f;
    private float _repeatRateTimeHealthPoints = 150f;
    
    
    void Start()
    {
        InvokeRepeating("CoinSpawner", _timeToSpawnCoin, _repeatRateTimeCoin);
        InvokeRepeating("HealthPointSpawner", _timeToSpawnHealthPoints, _repeatRateTimeHealthPoints) ;
    }


    private void CoinSpawner()
    {
        float randomXpoint = Random.Range(-27, -73);
        float randomZpoint = Random.Range(-27, -78);
        
        Instantiate(_coin, new Vector3(randomXpoint, 1, randomZpoint), Quaternion.identity, _coinAndHealthContainer);
        
    }

    private void HealthPointSpawner()
    {
        float randomXpoint = Random.Range(-30, -70);
        float randomZpoint = Random.Range(-30, -75);
        
        Instantiate(_healthPoints, new Vector3(randomXpoint, 1, randomZpoint), Quaternion.identity, _coinAndHealthContainer);

    }

    public static void IncreasEnemyCount()
    {
        EnemyCount++;
    }

    public static void DecreaseEnemyCount()
    {
        EnemyCount--;
    }

}
