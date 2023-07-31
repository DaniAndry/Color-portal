using UnityEngine;

public class DataLoader : MonoBehaviour
{
    private PlayerData _playerData;
    private JsonSaver _jsonSaver;

    private void Start()
    {
        _jsonSaver = GetComponent<JsonSaver>();
    }

    public void LoadPlayerData()
    {
        _playerData = _jsonSaver.LoadData();

        PlayerPrefs.SetInt("PlayerPoints", _playerData.PlayerPoints);
        PlayerPrefs.SetInt("ScoreCount", _playerData.ScoreCount);
    }
}
