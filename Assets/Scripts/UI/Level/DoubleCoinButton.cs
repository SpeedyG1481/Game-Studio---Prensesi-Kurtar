using System;
using GoogleMobileAds.Api;
using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

public class DoubleCoinButton : MonoBehaviour, IButtonListener
{
    private RewardBasedVideoAd _rewarded;
    public int coinAmount = 0;

    private string androidAdId = "ca-app-pub-8847668020520840/2004658060";
    private string iOSAdId = "ca-app-pub-8847668020520840/7256984740";

    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }


    private void RewardedAdLoad()
    {
        var adId = iOSAdId;
#if UNITY_ANDROID
        adId = androidAdId;
#endif
        _rewarded = RewardBasedVideoAd.Instance;
        var adRequest = new AdRequest.Builder().Build();
        _rewarded.LoadAd(adRequest, adId);
        _rewarded.OnAdLoaded += AdLoaded;
        _rewarded.OnAdRewarded += AdRewarded;
    }
    

    private void AdRewarded(object sender, Reward e)
    {
        GameController.AddCoin(coinAmount);
    }

    private void AdLoaded(object sender, EventArgs args)
    {
        _rewarded.Show();
    }
    
    public void OnClick()
    {
        _button.interactable = false;
        MobileAds.Initialize(x => { RewardedAdLoad(); });
    }
}