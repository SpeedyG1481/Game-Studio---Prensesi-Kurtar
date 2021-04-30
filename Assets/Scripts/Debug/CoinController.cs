using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
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
        GameController.AddCoin(10000);
    }
}