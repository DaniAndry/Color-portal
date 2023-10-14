using Agava.YandexGames;
using UnityEngine;

public class Ad : MonoBehaviour
{
    [SerializeField] private BonusSystem _bonusSystem;
    [SerializeField] private GameObject _bonusButton;
    [SerializeField] private SoundInGame _soundInGame;

    private int _pushCount;

    private bool _isEnough;
    private bool _isRun;

    public bool IsRun => _isRun;

    private void Start()
    {
        _pushCount = UnityEngine.PlayerPrefs.GetInt("PushCount", 0);

        if (HasEnoughClicks())
        {
            ShowBanner();
            _isEnough = false;
        }
    }

    public void ShowVideo()
    {
        VideoAd.Show(OpenAd, AddBonus, CloseAd);
    }

    public void CheckPushCount()
    {
        _pushCount++;
        UnityEngine.PlayerPrefs.SetInt("PushCount", _pushCount);
    }

    private bool HasEnoughClicks()
    {
        int needCount = 2;

        if (_pushCount >= needCount)
        {
            UnityEngine.PlayerPrefs.SetInt("PushCount", 0);
            _isEnough = true;
        }
        else
        {
            _isEnough = false;
        }
        return _isEnough;
    }

    private void ShowBanner()
    {
        InterstitialAd.Show(OpenInterstitialAd, CloseInterstitialAd);
        UnityEngine.PlayerPrefs.SetInt("PushCount", 0);
    }

    private void OpenInterstitialAd()
    {
        _isRun = true;
        Debug.Log("OpenAd");
        _soundInGame.StopSounds();
        Time.timeScale = 0;
    }

    private void OpenAd()
    {
        HideButton();
        _isRun = true;
        Debug.Log("OpenAd");
        _soundInGame.StopSounds();
        Time.timeScale = 0;
    }

    private void AddBonus()
    {
        _bonusSystem.AddBonus();
    }

    private void CloseAd()
    {
        Debug.Log("CloseAd");
        Time.timeScale = 1;
        _soundInGame.PlaySounds();
        _isRun = false;
    }

    private void CloseInterstitialAd(bool state)
    {
        Time.timeScale = 1;
        _soundInGame.PlaySounds();
        Debug.Log("CloseBannerAd");
        _isRun = false;
    }

    private void HideButton()
    {
        _bonusButton.SetActive(false);
    }
}
