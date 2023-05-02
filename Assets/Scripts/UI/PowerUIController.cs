using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUIController : MonoBehaviour
{
    [Header("Gameplay Controller")]
    [SerializeField] private IdContainer _IdProvider;

    [Header("Power UI List")]
    [SerializeField] private List<Sprite> _PowerUIList;

    [Header("Image")]
    [SerializeField] private Image _Image;

    private GameplayInputProvider _gameplayInputProvider;

    private void Awake()
    {
        _gameplayInputProvider = PlayerController.Instance.GetInput<GameplayInputProvider>(_IdProvider.Id);
        _Image.sprite = _PowerUIList[0];
    }

    private void OnEnable()
    {
        _gameplayInputProvider.OnUsedPower += PlayerPower;
        _gameplayInputProvider.OnPowerDelayEnd += PlayerDelayEnd;

    }
    private void OnDisable()
    {
        _gameplayInputProvider.OnUsedPower -= PlayerPower;
        _gameplayInputProvider.OnPowerDelayEnd -= PlayerDelayEnd;
    }

    private void PlayerPower()
    {
        _Image.sprite = _PowerUIList[1];
    }

    private void PlayerDelayEnd()
    {
        _Image.sprite = _PowerUIList[0];
    }
}
