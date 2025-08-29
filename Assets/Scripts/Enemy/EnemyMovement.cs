using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 50f;
    private PlayerStats _player;
    private Rigidbody _rigidbody;
    private Vector3 _playerDirection;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _player = PlayerStats.Instance;
    }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        
    }

    void FixedUpdate()
    {
        Movement();
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            _playerDirection = (_player.transform.position - transform.position).normalized;
            _moveDirection = _playerDirection;
            transform.forward = _moveDirection;
        }
        if(collision.gameObject.TryGetComponent<PlayerStats>(out var playerStats))
        {
            //transform.Rotate(0, 180f, 0);
            playerStats.TakeDamage();
        }
    }

    private void Movement()
    {
        _rigidbody.MovePosition(transform.position + _playerDirection * _moveSpeed * Time.fixedDeltaTime);
    }

    public void SetPlayerDirection( Vector3 _playerDirection)
    {
        this._playerDirection = (_playerDirection - transform.position).normalized;
    }

    


}
