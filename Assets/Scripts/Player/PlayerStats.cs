using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int _health = 3;
    private int _coinsPickedUp = 0;


    private void Start()
    {
        Debug.Log("Player Health: " + _health);
    }


    public void TakeDamage()
    {
        _health--;
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





}
