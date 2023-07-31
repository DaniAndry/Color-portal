using UnityEngine;

public class Unlocker : MonoBehaviour
{
    [SerializeField] private LevelUnlocker[] levelUnlockers;
    [SerializeField] private Points _points;
    [SerializeField] private NeedPoints _needPoints;

    private void Start()
    {
        for (int i = 0; i < levelUnlockers.Length; i++)
        {
            if (_needPoints.TryToEnter(i, _points.Calculate()))
            {
                levelUnlockers[i].StartToUnlock(_points.Calculate());
            }
        }
    }
}
