using UnityEngine;
using DG.Tweening;

public class Like3D : MonoBehaviour
{
    [SerializeField] private Transform _model;

    public void Move(int delay, Transform target)
    {
        float baseInterval = 0.3f;

        if (_model != null)
            _model.DORotate(Vector3.up * 359, 0.5f, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOPunchScale(Vector3.one * 0.5f, 0.3f, 8));
        sequence.AppendInterval(baseInterval * delay);
        sequence.Append(transform.DOMove(target.position + (Vector3.up * 12), 1.7f));
        sequence.OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
