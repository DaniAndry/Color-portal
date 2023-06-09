using DG.Tweening;
using UnityEngine;

public class ColorCube : Cube
{
    [SerializeField] private Cube _targetCube;
    [SerializeField] private ParticleSystem _particle;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.Teleportation(_targetCube.Center.transform.position);
            _particle.Play();
        }
    }
}
