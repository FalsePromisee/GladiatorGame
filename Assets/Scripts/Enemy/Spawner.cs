using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    

    void Start()
    {
        //Instantiate(_enemyPrefab, _spawnPoint, Quaternion.identity);
        InvokeRepeating("SpawnEnemy", 2f, 5f);
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, transform.position + transform.forward * 5, Quaternion.identity);
    }


    void Update()
    {
        
    }
}
