using UnityEngine;

public class Health : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerStats>(out var player))
        {
            player.RestoreHealthPoints();
            Destroy(gameObject);
        }     
    }
}
