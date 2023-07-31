using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class InitializingSDK : MonoBehaviour
{
    public UnityAction SDKInitialized;

    [SerializeField] DataLoader _dataLoader;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
        PlayerPrefs.SetFloat("SoundVolume", 100);
        PlayerPrefs.SetFloat("MusicVolume", 100);
    }


    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        if (SDKInitialized != null)
        {
            SDKInitialized?.Invoke();
            PlayerPrefs.SetString("_currentLanguage", YandexGamesSdk.Environment.i18n.lang);
            _dataLoader.LoadPlayerData();
        }

    }

    //#endif

#if VK_GAMES && UNITY_WEBGL && !UNITY_EDITOR

    private IEnumerator Start()
    {
        yield return VKGamesSdk.Initialize();
    }

#endif
}
