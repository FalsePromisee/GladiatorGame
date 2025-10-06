using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private GameObject _playerUI;
    [SerializeField] private GameObject _deathUI;
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private TMP_Text _healthText;
    

    private void Start()
    {
        _playerUI.SetActive(true);
        _deathUI.SetActive(false);
        _coinText.text = _playerStats.CoinAmount().ToString();
        _healthText.text = _playerStats.HealthAmount().ToString();
        
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameOver() == true)
        {
            _playerUI.SetActive(false);
            _deathUI.SetActive(true);
        }
    }
    
    private void OnEnable()
    {
        _playerStats.OnCoinsPickedUp += OnPlayerPickUpCoin;
        _playerStats.OnHealthChanged += OnPlayerPickUpHealthPoint;
    }

    private void OnPlayerDeath()
    {
        _playerUI.SetActive(false);
        _deathUI.SetActive(true);
    }

    private void OnPlayerPickUpHealthPoint(int healthPoint)
    {
        _healthText.text = healthPoint.ToString();
    }

    private void OnDisable()
    {
        _playerStats.OnCoinsPickedUp -= OnPlayerPickUpCoin;
        _playerStats.OnHealthChanged -= OnPlayerPickUpHealthPoint;
    }
    
    private void OnPlayerPickUpCoin(int coin)
    {
        _coinText.text = coin.ToString();
    }
}
