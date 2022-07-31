using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(PointTarget))]
public class Survival : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name = "Default";
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Animator _animator;

    private PointTarget _pointTarget;

    public Sprite Icon => _icon;
    public string Name => _name;
    public PointTarget PointTargetComponent => _pointTarget;

    public event UnityAction<Survival> Saved;

    private void Awake()
    {
        _pointTarget = GetComponent<PointTarget>();
        _pointTarget.SetIcon(_icon);   
    }

    private void OnEnable()
    {
        _finishPlatform.PlayerReached += OnPlayerReached;
    }
    private void OnDisable()
    {
        _finishPlatform.PlayerReached -= OnPlayerReached;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack);
            Saved?.Invoke(this);
            //TargetDestroyed?.Invoke();
            _pointTarget.OnTargetDestroy();
        }
    }

    private void OnPlayerReached()
    {
        _animator.SetTrigger(AnimatorSurvivals.Trigger.LevelComplite);
    }


    public static class AnimatorSurvivals
    {
        public static class Trigger
        {
            public const string LevelComplite = nameof(LevelComplite);
        }
    }
}
