using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FirePlace : MonoBehaviour
{
    [SerializeField] private float _radius = 1;
    [SerializeField] private float _delay = 0.3f;

    private int _savedCount;

    public void PlaceSaved(IReadOnlyList<Survival> saved)
    {
        _savedCount = saved.Count;

        for (int i = 0; i < saved.Count; i++)
        {
            Transform savedTransform = saved[i].transform;

            savedTransform.parent = transform;
            savedTransform.localPosition = GetPosition(i);
            savedTransform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack).SetDelay(_delay * i);
            savedTransform.DOLookAt(this.transform.position, 0.5f, AxisConstraint.Y);
        }
    }

    private Vector3 GetPosition(int i)
    {
        float degrees = 360 / _savedCount;
        var radians = degrees * Mathf.Deg2Rad;

        var x = Mathf.Cos(radians * i) * _radius;
        var z = Mathf.Sin(radians * i) * _radius;
        return new Vector3(x, 0, z);
    }
}
