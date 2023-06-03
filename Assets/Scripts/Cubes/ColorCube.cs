using DG.Tweening;
using UnityEngine;

public class ColorCube : Cube
{
    [SerializeField] private Cube _targetCube;
    [SerializeField] private ParticleSystem _particle;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerTeleport>(out PlayerTeleport player))
        {
            player.Teleportation(_targetCube.Center.transform.position);
            _particle.Play();
        }
    }
}
