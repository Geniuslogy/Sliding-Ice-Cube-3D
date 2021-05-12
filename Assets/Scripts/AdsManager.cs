using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{

    public static AdsManager instance;

    string GameID = "4119953";

    bool EnableTestMode = true;

    string RewardedAndroidAdUnitID = "Rewarded_Android";

    string BannerAndroidAdUnitID = "Banner_Android";


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(GameID);
        Advertisement.AddListener(this);

        // StartCoroutine("ShowBannerAds");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowVideoAds()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    public void ShowRewardedVideoAds()
    {
        if (Advertisement.IsReady(RewardedAndroidAdUnitID))
        {
            Advertisement.Show(RewardedAndroidAdUnitID);
        }
    }

    IEnumerator ShowBannerAds()
    {
        while (!Advertisement.IsReady(BannerAndroidAdUnitID))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(BannerAndroidAdUnitID);
    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            GameManager.instance.Restart();
        }
    }

}
