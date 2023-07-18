using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsInMenu : MonoBehaviour
{
    [SerializeField] private List<Image> _stars;
    [SerializeField] private int _level;

    public void Start()
    {
        int starsCount = PlayerPrefs.GetInt("PointsLevel" + _level, 0);

        for (int i = 0; i < starsCount; i++)
        {
            _stars[i].color = new Color(255, 255, 255, 255);
        }
    }
}