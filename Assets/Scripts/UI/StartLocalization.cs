using Agava.YandexGames;
using UnityEngine;

public class StartLocalization : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetString("_currentLanguage", YandexGamesSdk.Environment.i18n.lang);
    }
}
