using UnityEngine;

[RequireComponent(typeof(Resizer))]
public class Tutor : MonoBehaviour
{
    [SerializeField] private Resizer _resizer;
    [SerializeField] private ParticleSystem _particle;

    private void OnTriggerEnter(Collider other)
    {
        _resizer.Resize(1f, 0);

        if (_particle != null)
        {
            _particle.Stop();
        }
    }
}
