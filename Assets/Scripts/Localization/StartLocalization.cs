using Agava.YandexGames;
using UnityEngine;

public class StartLocalization : MonoBehaviour
{
    private void Start()
    {
        UnityEngine.PlayerPrefs.SetString("_currentLanguage", YandexGamesSdk.Environment.i18n.lang);
    }
}
