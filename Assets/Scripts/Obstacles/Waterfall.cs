using UnityEngine;

public class Waterfall : MonoBehaviour, IDamper
{
    [SerializeField] private ParticleSystem[] _water;
    [SerializeField] private ParticleSystem[] _acid;
    [SerializeField] private float _interval;

    private float _current;
    private FlowType _currentType;
    private Collider _collider;

    private enum FlowType
    {
        Water,
        Acid
    }

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void Start()
    {
        ActivateWater();
    }

    public void ActivateWater()
    {
        _currentType = FlowType.Water;
        _collider.enabled = false;

        foreach (ParticleSystem particleSystem in _acid)
            particleSystem.Stop();

        foreach (ParticleSystem particleSystem in _water)
            particleSystem.Play();
    }

    public void ActivateAcid()
    {
        _currentType = FlowType.Acid;
        _collider.enabled = true;

        foreach (ParticleSystem particleSystem in _water)
            particleSystem.Stop();

        foreach (ParticleSystem particleSystem in _acid)
            particleSystem.Play();
    }

    private void Update()
    {
        _current += Time.deltaTime;
        if (_current >= _interval)
        {
            _current = 0;
            Switch();
        }
    }

    private void Switch()
    {
        if (_currentType == FlowType.Water)
            ActivateAcid();
        else if (_currentType == FlowType.Acid)
            ActivateWater();
    }

    
}


