using UnityEngine;
using DG.Tweening;
using System;

public class Stepway : MonoBehaviour
{
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private Transform _point3;

    public void MovePlayer(Transform player, Action callback)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(player.DOMove(_point1.position, 1f).SetEase(Ease.Linear));
        sequence.Append(player.DOMove(_point2.position, 1.2f).SetEase(Ease.Linear));
        sequence.Append(player.DOMove(_point3.position, 1.2f).SetEase(Ease.Linear));
        sequence.Append(player.DOLookAt(new Vector3(-20, 0, 20), 0.5f, AxisConstraint.Y));
        sequence.OnComplete(() =>
        {
            callback();
        });
    }
}
