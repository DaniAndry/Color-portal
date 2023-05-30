using DG.Tweening;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private GameObject _center;
    [SerializeField] private Cube _targetCube;

    public GameObject Center => _center;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.Teleportation(_targetCube.Center.transform.position);
        }
    }
}
