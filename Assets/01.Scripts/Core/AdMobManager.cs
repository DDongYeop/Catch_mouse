using UnityEngine;
using GoogleMobileAds.Api;
 
public class AdmobManager : MonoBehaviour
{
    public static AdmobManager Instance;

    private string adUnitId = "ca-app-pub-5714181718235393/5070112473";
 
    private RewardedAd rewardedAd;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple AdmobManager is running");
        Instance = this;
    }

    void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            //초기화 완료
        });
        
        LoadRewardedAd();
    }
 
    public void LoadRewardedAd() //광고 로드 하기
    {
        // Clean up the old ad before loading a new one.
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }
 
        Debug.Log("Loading the rewarded ad.");
 
        // create our request used to load the ad.
        var adRequest = new AdRequest.Builder().Build();
 
        // send the request to load the ad.
        RewardedAd.Load(adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }
 
                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());
 
                rewardedAd = ad;
            });
    }
 
    public void ShowAd() //광고 보기
    {
        const string rewardMsg =
            "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";
 
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                //보상 획득하기
                Debug.Log(string.Format(rewardMsg, reward.Type, reward.Amount));
            });
        }
        else
        {
            GameManager.Instance.Money += 40;
            LoadRewardedAd();
        }
    }
 
    private void RegisterReloadHandler(RewardedAd ad) //광고 재로드
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += (null);
        {
            Debug.Log("Rewarded Ad full screen content closed.");
 
            // Reload the ad so that we can show another as soon as possible.
            LoadRewardedAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
 
            // Reload the ad so that we can show another as soon as possible.
            LoadRewardedAd();
        };
    }
}