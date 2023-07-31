using Lean.Localization;
using UnityEngine;

public class Localization : MonoBehaviour
{
    [SerializeField] private LeanLocalization _leanLocalization;
    private string _language;

    private void Start()
    {
        _language = PlayerPrefs.GetString("_currentLanguage");
        SelectLocalization(_language);
    }

    private void Select()
    {
        _language = PlayerPrefs.GetString("_currentLanguage");
        SelectLocalization(_language);
        Debug.Log(_language);
    }

    private void SelectLocalization(string language)
    {
        switch (language)
        {
            case "ru":
                LoadLocalizationRu();
                break;
            case "en":
                LoadLocalizationEn();
                break;
            case "tr":
                LoadLocalizationTr();
                break;
        }
    }

    private void LoadLocalizationRu()
    {
        _leanLocalization.SetCurrentLanguage("Russian");
    }

    private void LoadLocalizationEn()
    {
        Debug.Log("ENglish");
        _leanLocalization.SetCurrentLanguage("English");
    }

    private void LoadLocalizationTr()
    {
        Debug.Log("tur");
        _leanLocalization.SetCurrentLanguage("Turkish");
    }

}
