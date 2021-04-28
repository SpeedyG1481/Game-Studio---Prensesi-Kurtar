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


            _interstitial = new InterstitialAd(adId);
            var adRequest = new AdRequest.Builder().Build();
            _interstitial.LoadAd(adRequest);
            _interstitial.OnAdLoaded += AdLoaded;
        }

        private void AdLoaded(object sender, EventArgs e)
        {
            _interstitial.Show();
        }
    }
}