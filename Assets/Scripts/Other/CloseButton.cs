using System;
using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour, IButtonListener
{
    private GameObject _gameObject;
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _gameObject = GameObject.Find("InputGUI");
        _button.onClick.AddListener(OnClick);
        
    }

    public void OnClick()
    {
        _gameObject.SetActive(false);
    }
}