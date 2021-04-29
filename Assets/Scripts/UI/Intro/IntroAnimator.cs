using UI.Loader;
using UnityEngine;

namespace UI.Intro
{
    public class IntroAnimator : MonoBehaviour
    {
        private float _timer;
        private const float IntroTime = 6.25F;


        void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= IntroTime)
            {
                SceneLoader.Load(Scenes.Menu);
            }
        }
    }
}