using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyContainer;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private PlayerStats _player;

    private float _startSpawnTime = 5f;
    private float _spawnInterval = 10f;


    void Start()
    {
        //Instantiate(_enemyPrefab, _spawnPoint, Quaternion.identity);
        InvokeRepeating("SpawnEnemy", _startSpawnTime, _spawnInterval);
        

    }

    private void SpawnEnemy()
    {
        SpawnManager.IncreasEnemyCount();
        if (SpawnManager.EnemyCount <= 2)
        {
            float spawnOffset = 10f;
            Vector3 enemyRotation = (_player.transform.position - transform.position).normalized;
            var Enemy = Instantiate(_enemyPrefab, transform.position + transform.forward * spawnOffset, Quaternion.LookRotation(enemyRotation), _enemyContainer);
            Enemy.GetComponent<EnemyMovement>().SetPlayerDirection(_player.transform.position);
        }
        else
        {
            return;
        }
        
    }

}
