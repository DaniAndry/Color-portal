using UnityEngine;
using System.Collections.Generic;

public class FinalCube : Cube
{
    [SerializeField] private List<ParticleSystem> _particles;
    [SerializeField] private GameObject _panel;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            foreach (ParticleSystem particle in _particles)
            {
                particle.Play();
            }

            Invoke(nameof(OnPanel), 1f);
            Destroy(player.gameObject);
        }
    }

    private void OnPanel()
    {
        _panel.SetActive(true);
    }
}
