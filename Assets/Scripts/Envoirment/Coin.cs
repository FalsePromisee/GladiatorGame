using System;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _maxLifeTime = 30f;
    private float _lifeTime;
    
    private bool _isCreated = false;

    private void Update()
    {
        AutoDestroy();
    }

    private void AutoDestroy()
    {
        if (_isCreated)
        {
            _lifeTime += Time.deltaTime;
        }

        if (_lifeTime > _maxLifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerStats>(out var player))
        {
            player.PickUpCoin();
            Destroy(gameObject);
        }
        
    }

    private void OnEnable()
    {
        _isCreated = true;
    }
    
}
