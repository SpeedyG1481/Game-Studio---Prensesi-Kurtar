using GoogleMobileAds.Api;
using UI.Loader;
using UnityEngine;

namespace UI.Intro
{
    public class IntroAnimator : MonoBehaviour
    {
        private float _timer;
        public float introTime = 5F;

        private void Start()
        {
            MobileAds.Initialize(x => { });
        }

        void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > introTime)
            {
                SceneLoader.Load(Scenes.Menu);
            }
        }
    }
}