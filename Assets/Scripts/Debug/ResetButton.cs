using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Listener);
    }

    private void Update()
    {
        if (!GameController.DebugMode)
            Destroy(gameObject);
    }

    private void Listener()
    {
        PlayerPrefs.DeleteAll();
    }
}
