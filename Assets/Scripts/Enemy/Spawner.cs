using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyContainer;
    
    [SerializeField] private GameObject _enemyPrefab;

    

    void Start()
    {
        //Instantiate(_enemyPrefab, _spawnPoint, Quaternion.identity);
        InvokeRepeating("SpawnEnemy", 2f, 5f);
    }

    private void SpawnEnemy()
    {
        float spawnOffset = 5f;
        Instantiate(_enemyPrefab, transform.position + transform.forward * spawnOffset, Quaternion.identity, _enemyContainer);
    }

}
