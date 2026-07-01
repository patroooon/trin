using Firebase;
using Firebase.Analytics;
using Firebase.Crashlytics;
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

            // Проверяем и исправляем зависимости Firebase на устройстве
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => 
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    // Зависимости в порядке, можно инициализировать сервисы
                    FirebaseApp app = FirebaseApp.DefaultInstance;

                    // Настройка Crashlytics (опционально, но рекомендуется)
                    Crashlytics.ReportUncaughtExceptionsAsFatal = true;
                
                    // Пример отправки тестового события в Analytics
                    FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLogin);

                    Debug.Log("Firebase успешно инициализирован.");
                }
                else
                {
                    Debug.LogError($"Не удалось разрешить зависимости Firebase: {dependencyStatus}");
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