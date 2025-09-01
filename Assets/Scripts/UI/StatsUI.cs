using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private Image _jumpPower;

    private void Update()
    {
        _jumpPower.fillAmount = FirstPersonController.Instance.GetJumpPower();
    }


}
