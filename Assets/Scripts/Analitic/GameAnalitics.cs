using Firebase;
using Firebase.Analytics;
using UnityEngine;

namespace TrafficInfinity
{
    public class GameAnalitics : MonoBehaviour
    {
        public static GameAnalitics gameAnalytics;
        
        private bool _canUseAnalytics;

        void Awake()
        {
            if (gameAnalytics == null)
            {
                gameAnalytics = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);

            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == Firebase.DependencyStatus.Available)
                {
                    // Create and hold a reference to your FirebaseApp,
                    // where app is a Firebase.FirebaseApp property of your application class.
                    _canUseAnalytics = true;
                    //  var app = FirebaseApp.DefaultInstance;
                    // Set a flag here to indicate whether Firebase is ready to use by your app.
                }
                else
                {
                    Debug.LogError(System.String.Format(
                        "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                    // Firebase Unity SDK is not safe to use here.
                }
            });
        }


        public void InAppPurchaseEvent()
        {
            if (!_canUseAnalytics)
                return;
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventPurchase);
        }


        public void InterstitialAd()
        {
            if (!_canUseAnalytics)
                return;

            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventAdImpression,
                new Parameter("Ad_Type", "Interstitial_Ad"));
        }

        public void RewardedAd()
        {
            if (!_canUseAnalytics)
                return;
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventAdImpression, new Parameter("Ad_Type", "Rewarded_Ad"));
        }

        public void BannerAd()
        {
            if (!_canUseAnalytics)
                return;
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventAdImpression, new Parameter("Ad_Type", "Banner_Ad"));
        }

        public void LogEvent(string eventName)
        {
            if (!_canUseAnalytics)
                return;
            FirebaseAnalytics.LogEvent(eventName);
        }

        public void LevelUp(int eventName)
        {
            if (!_canUseAnalytics)
                return;
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelUp,
                new Parameter(FirebaseAnalytics.ParameterLevel, eventName));
        }
    }
}