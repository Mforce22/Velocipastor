using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsViewController : MonoBehaviour
{

    [Header("UI image list")]
    [SerializeField] private List<Sprite> _controls;

    [Header("UI image")]
    [SerializeField] private Image _image;

    public void CloseControls()
    {
        Destroy(gameObject);
    }

    public void setImage(string name)
    {
        switch (name)
        {
            case "Keyboard":
                //_image.SourceImage = _controls[0];
                _image.sprite = _controls[0];
                Debug.Log(name);
                break;
            default:
                _image.sprite = _controls[0];
                break;
        }
    }
}
