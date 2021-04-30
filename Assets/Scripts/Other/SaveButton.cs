using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour, IButtonListener
{
    public GameObject gameObject;
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        gameObject.SetActive(true);
    }
}