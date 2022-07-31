using System.Collections;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    private IEnumerator _resizeCoroutine;

    public void Resize(float time, float size)
    {
        Resize(time, new Vector3(size, size, size));
    }

    public void Resize(float time, Vector3 size)
    {
        if (_resizeCoroutine != null)
            StopCoroutine(_resizeCoroutine);

        _resizeCoroutine = ResizeCoroutine(time, size);
        StartCoroutine(_resizeCoroutine);
    }

    private IEnumerator ResizeCoroutine(float time, Vector3 target)
    {
        float Timer = 0;
        Vector3 Base = _transform.localScale;

        while (Timer < time)
        {
            _transform.localScale = Vector3.Lerp(Base, target, Timer / time);
            yield return null;
            Timer += Time.deltaTime;
        }

        _transform.localScale = target;
        _resizeCoroutine = null;
    }
}