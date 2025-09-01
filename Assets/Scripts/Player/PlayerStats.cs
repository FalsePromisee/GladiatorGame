using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    

    private int _health = 3;
    private int _maxHealth = 3;
    private int _coinsPickedUp = 0;

    private float _imuneTime = 2f;


    private void Start()
    {
        Debug.Log("Player Health: " + _health);
        Instance = this;
    }

    private void Update()
    {
        _imuneTime += Time.deltaTime;
    }


    public void TakeDamage()
    {
        if (_imuneTime > 2f)
        {
            _health--;
            _imuneTime = 0f;
            Debug.Log("Player took damage");
        }
        Debug.Log("Player Health: " + _health);
        if (_health <= 0)
        {
            Debug.Log("Player Dead");
        }
    }

    public void PickUpCoin()
    {
        _coinsPickedUp++;
        Debug.Log("Coins: " +  _coinsPickedUp);
    }

    public void RestoreHealthPoints()
    {
        _health++;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        Debug.Log("Health: " + _health);
    }





}
