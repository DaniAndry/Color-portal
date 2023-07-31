using UnityEngine;

public class JsonSaver : MonoBehaviour
{
    public void SaveData(PlayerData playerData)
    {
        string jsonData = JsonUtility.ToJson(playerData);
        string savePath = Application.persistentDataPath + "/SaveData.json";

        System.IO.File.WriteAllText(savePath, jsonData);

        Debug.Log("Json Save" + jsonData);
    }

    public PlayerData LoadData()
    {
        string savePath = Application.persistentDataPath + "/SaveData.json";

        if (System.IO.File.Exists(savePath))
        {
            string jsonData = System.IO.File.ReadAllText(savePath);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonData);
            return playerData;
        }
        else
        {
            Debug.LogWarning("Save file not found.");
            return null;
        }
    }
}
