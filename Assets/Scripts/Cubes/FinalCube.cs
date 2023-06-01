using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;

public class FinalCube : Cube
{
    [SerializeField] private List<ParticleSystem> _particles;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            foreach (ParticleSystem particle in _particles)
            {
                particle.Play();
            }

            Destroy(player.gameObject);
        }
    }
}
