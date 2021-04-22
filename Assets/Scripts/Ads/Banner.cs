using GoogleMobileAds.Api;
using UnityEngine;

namespace Ads
{
    public class Banner : MonoBehaviour
    {
        private BannerView _bannerView;

        private string androidAdId = "ca-app-pub-8847668020520840/2250369959";
        private string iOSAdId = "ca-app-pub-8847668020520840/7082720774";

        void Start()
        {
            MobileAds.Initialize(x => { BannerAd(); });
        }

        private void BannerAd()
        {
            var adId = iOSAdId;
#if UNITY_ANDROID
            adId = androidAdId;
#endif
            _bannerView = new BannerView(adId, AdSize.SmartBanner, AdPosition.Bottom);
            var adRequest = new AdRequest.Builder().Build();
            _bannerView.LoadAd(adRequest);
        }
    }
}