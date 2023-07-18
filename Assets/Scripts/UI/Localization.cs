using Lean.Localization;
using UnityEngine;

public class Localization : MonoBehaviour
{
    [SerializeField] private LeanLocalization _leanLocalization;
    private string _language;

    private void Start()
    {
        _language = PlayerPrefs.GetString("_currentLanguage");
        SelectLocalization();
        Debug.Log(_language);
    }


    private void Select()
    {
        _language = PlayerPrefs.GetString("_currentLanguage");
        SelectLocalization();
        Debug.Log(_language);
    }

    private void SelectLocalization()
    {
        if (_language == "ru")
        {
            LoadLocalizationRu();
        }
        if (_language == "en")
        {
            LoadLocalizationEn();
        }
        if (_language == "tr")
        {
            LoadLocalizationTr();
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
