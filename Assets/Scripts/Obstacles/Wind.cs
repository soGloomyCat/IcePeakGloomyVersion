using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class Wind : MonoBehaviour
{
    [SerializeField] private float _workTime = 2;
    [SerializeField] private float _interval = 1;
    [SerializeField] private float _power = 1;
    [SerializeField] private WindDirection _direction;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private WindIndicator _windIndicator;

    private BoxCollider _boxCollider;

    public WindDirection Direction => _direction;
    public float Power => _power;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _boxCollider.isTrigger = true;
        _boxCollider.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(DelayActivate());
    }

    private IEnumerator DelayActivate()
    { 
        yield return new WaitForSeconds(_interval);
        Activate();
        StartCoroutine(DelayDeActivate());
    }

    private IEnumerator DelayDeActivate()
    {
        yield return new WaitForSeconds(_workTime);
        DeActivate();
        StartCoroutine(DelayActivate());
    }

    private void Activate()
    {
        _effect.Play();
        _boxCollider.enabled = true;
        _windIndicator.Activate();
    }

    private void DeActivate()
    { 
        _effect.Stop();
        _boxCollider.enabled = false;
        _windIndicator.Deactivate();
    }
}

public enum WindDirection
{ 
    Left = -1,
    Right = 1
}
