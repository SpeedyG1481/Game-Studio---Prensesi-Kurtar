using UI.Loader;
using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoaderButton : MonoBehaviour, IButtonListener
{
    public Scenes scene;
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (scene != null)
            SceneLoader.Load(scene);
    }
}