using TMPro;
using UnityEngine;

public class PlayerScore : Score
{
    [SerializeField] private TMP_Text _rank;

    public void SetRank(int rank)
    {
        _rank.text = rank.ToString();
    }
}