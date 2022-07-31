using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(PointTarget))]
public class Stone : MonoBehaviour, IDamper
{
    [SerializeField] private ParticleSystem _destroyEffect;
    [SerializeField] private GameObject _model;

    private Collider _collider;
    private PointTarget _pointTarget;

    private Tween _movement;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _pointTarget = GetComponent<PointTarget>();
    }

    public void Move()
    {
        _movement = transform.DOLocalMoveY(-100, 5f).SetEase(Ease.Linear);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FallingObjectsDestroyer objectsDestroyer))
        {
            DestroyStone();
        }
        else if (other.TryGetComponent(out Player player))
        {
            _destroyEffect.Play();
            DestroyStone();
        }
    }

    private void DestroyStone()
    {
        _movement.Kill();
        _model.SetActive(false);
        _collider.enabled = false;
        //TargetDestroyed.Invoke();
        _pointTarget.OnTargetDestroy();
        Destroy(gameObject, 2f);
    }
}
