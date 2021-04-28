using System;
using GoogleMobileAds.Api;
using UnityEngine;

namespace Ads
{
    public class MarketInterstitial : MonoBehaviour
    {
        private InterstitialAd _interstitial;

        private string androidAdId = "ca-app-pub-8847668020520840/7274292467";
        private string iOSAdId = "ca-app-pub-8847668020520840/2653710546";

        void Start()
        {
            MobileAds.Initialize(x => { InterstitialAdLoad(); });
        }

        private void InterstitialAdLoad()
        {
            var adId = iOSAdId;
            if (Application.platform == RuntimePlatform.Android)
            {
                adId = androidAdId;
            }

            if (GameController.DebugMode)
                adId = GameController.AdmobTestInterstitial;

            _interstitial = new InterstitialAd(adId);
            var adRequest = new AdRequest.Builder().Build();
            _interstitial.OnAdLoaded += AdLoaded;
            _interstitial.LoadAd(adRequest);
            if (GameController.DebugMode)
                _interstitial.OnAdFailedToLoad += AdFailed;
        }

        private void AdFailed(object sender, AdFailedToLoadEventArgs e)
        {
            Debug.Log(e.Message);
        }

        private void AdLoaded(object sender, EventArgs e)
        {
            _interstitial.Show();
        }
    }
}