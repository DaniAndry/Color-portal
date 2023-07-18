using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class InitializingSDK : MonoBehaviour
{
    public UnityAction SDKInitialized;
    private int _levels = 13;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
        ClearState();
        PlayerPrefs.SetFloat("SoundVolume", 100);
        PlayerPrefs.SetFloat("MusicVolume", 100);
    }

    private void ClearState()
    {
        for (int i = 0; i < _levels; i++)
        {
            PlayerPrefs.SetInt("PointsLevel" + i, 0);
        }
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        if (SDKInitialized != null)
        {
            SDKInitialized?.Invoke();
            PlayerPrefs.SetString("_currentLanguage", YandexGamesSdk.Environment.i18n.lang);
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
