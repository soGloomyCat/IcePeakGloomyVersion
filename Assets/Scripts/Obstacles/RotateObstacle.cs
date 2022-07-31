using UnityEngine;
using DG.Tweening;

public class RotateObstacle : MonoBehaviour
{
    [SerializeField] private Transform _rotatingModel;
    [SerializeField] private float _rotateTime;

    private void Start()
    {
        _rotatingModel.DORotate(Vector3.forward * 180, _rotateTime, RotateMode.Fast).SetEase(Ease.Linear).SetLoops(-1);
    }
}
