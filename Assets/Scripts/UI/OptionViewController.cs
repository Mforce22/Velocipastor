using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionViewController : MonoBehaviour
{

    [SerializeField] private ControlsViewController _ControlsViewPrefab;

    private ControlsViewController _controlsViewController;

    public void CloseOptions()
    {
        Destroy(gameObject);
    }

    public void showCommands(string name)
    {
        if (_controlsViewController)
        {
            return;
        }
        _controlsViewController = Instantiate(_ControlsViewPrefab);
        _ControlsViewPrefab.setImage(name);
        _controlsViewController.setImage(name);
    }
}
