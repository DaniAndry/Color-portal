using UnityEngine;

public class NeedPoints : MonoBehaviour
{
    public bool TryToEnter(int numberLevel, int countPoints)
    {
        int needpoints = 2;

        for (int i = 0; i < numberLevel; i++)
        {
            needpoints += 2;
        }

        if (countPoints >= needpoints)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
