using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyContainer;
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private PlayerStats _player;

    [SerializeField] private float _startSpawnTime = 5f;
    [SerializeField] private float _spawnInterval = 10f;


    void Start()
    {
        InvokeRepeating("SpawnEnemy", _startSpawnTime, _spawnInterval);
    }

    private void SpawnEnemy()
    {
        SpawnManager.IncreasEnemyCount();
        if (SpawnManager.EnemyCount <= SpawnManager.MaxEnemyCount)
        {
            RandomEnemySpawn();
        }
        else
        {
            return;
        }
        
    }

    private void RandomEnemySpawn()
    {
        float spawnOffset = 10f;
        Vector3 playerPosition = _player.transform.position - transform.position;
        playerPosition.y = 0;
        playerPosition.Normalize();
        Vector3 enemyRotation = playerPosition;
        int randomEnemySpawn = Random.Range(0, _enemyPrefab.Length);
        var Enemy = Instantiate(_enemyPrefab[randomEnemySpawn], transform.position + transform.forward * spawnOffset, Quaternion.LookRotation(enemyRotation), _enemyContainer);
        Enemy.GetComponent<EnemyMovement>().SetPlayerDirection(_player.transform.position);
    }
}
