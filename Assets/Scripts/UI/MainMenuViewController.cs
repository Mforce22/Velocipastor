using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuViewController : MonoBehaviour
{
    [SerializeField] private OptionViewController _OptionPrefab;

    private OptionViewController _optionViewController;
    public void ChangeScene(string name)
    {
        TravelSystem.Instance.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenOption()
    {
        if (_optionViewController)
        {
            return;
        }
        _optionViewController = Instantiate(_OptionPrefab);

    }
}
