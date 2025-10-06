using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private FirstPersonController _playerController;
    
    private bool _isGameOver;

    private void Awake()
    {
        Instance = this;
        _playerController.enabled = true;
        _isGameOver = false;
    }

    private void Update()
    {
        if (_isGameOver)
        {
            _playerController.enabled = false;
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnEnable()
    {
        _playerStats.OnGameOver += OnPlayerDeath;
    }

    private void OnDisable()
    {
        _playerStats.OnGameOver -= OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        _isGameOver = true;
    }

    public bool IsGameOver()
    {
        return _isGameOver;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    
}
