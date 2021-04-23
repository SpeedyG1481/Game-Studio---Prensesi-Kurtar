using UI.Loader;
using UnityEngine;

public class IntroAnimator : MonoBehaviour
{
    private float _timer = 0F;
    public float introTime = 5F;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > introTime)
        {
            SceneLoader.Load(Scenes.Menu);
        }
    }
}