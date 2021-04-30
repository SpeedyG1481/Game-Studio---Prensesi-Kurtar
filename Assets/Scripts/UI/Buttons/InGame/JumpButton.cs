using Entity;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler
{
    private Character _character;

    private void Start()
    {
        _character = FindObjectOfType<Character>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (_character != null && !_character.IsDead())
            _character.Jump();
    }
}