using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;
using UnityEngine.UI;

public class InSaveButton : MonoBehaviour
{
    private InputField _field;
    private GameObject _gameObject;
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _field = GameObject.Find("UsernameField").GetComponent<InputField>();
        _gameObject = GameObject.Find("InputGUI");
        _button.onClick.AddListener(OnClick);
    }

    public async void OnClick()
    {
        _gameObject.SetActive(false);
        if (_field.text.Length > 1)
        {
            var username = _field.text;
            _field.text = "";

            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                {"username", username},
                {"point", GameController.GlobalLevelPointer.ToString()},
                {"time", GameController.GlobalLevelTimer.ToString()},
            };

            var content = new FormUrlEncodedContent(values);

            var response =
                await client.PostAsync(
                    "https://studio.megalowofficial.com/api/games/rescuetheprincess/insert_new_data.php", content);
        }
    }
}