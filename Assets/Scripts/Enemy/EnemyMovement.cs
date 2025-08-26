using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 50f;
    private Rigidbody _rigidbody;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
        Movement();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Wall>(out var wall) || collision.gameObject.TryGetComponent<Spawner>(out var spawner))
        {
            transform.Rotate(0, 180f, 0);
        }
        if(collision.gameObject.TryGetComponent<PlayerStats>(out var playerStats))
        {
            transform.Rotate(0, 180f, 0);
            playerStats.TakeDamage();
        }
    }

    private void Movement()
    {
        _rigidbody.MovePosition(transform.position + transform.forward * _moveSpeed * Time.deltaTime);
    }

}
