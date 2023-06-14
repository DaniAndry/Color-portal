using UnityEngine;

public class Points : MonoBehaviour
{
    private static int _count;

    public int Count => _count;


    public void AddPoints(int count)
    {
        _count += count;
    }
}
