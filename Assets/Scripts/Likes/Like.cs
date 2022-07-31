using UnityEngine;
using DG.Tweening;

public class Like : MonoBehaviour
{
    public void Move(int delay)
    {
        float baseInterval = 0.1f;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOPunchScale(Vector3.one * 0.5f, 0.3f, 8));
        sequence.AppendInterval(baseInterval * delay);
        sequence.Append(transform.DOLocalMoveY(1500, 1.5f));
        sequence.OnComplete(() => 
        {
            Destroy(gameObject);
        });
    }
}
