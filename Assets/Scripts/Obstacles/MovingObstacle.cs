using UnityEngine;
using DG.Tweening;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private float _moveTime;
    [SerializeField] private Transform _movingModel;
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;

    private void Awake()
    {
        _movingModel.localPosition = _point1.localPosition;
    }

    private void Start()
    {
        Move();
    }

    private void Move()
    {
        _movingModel.DOLocalMove(_point2.localPosition, _moveTime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
