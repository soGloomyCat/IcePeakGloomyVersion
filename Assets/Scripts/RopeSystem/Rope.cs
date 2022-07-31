using System.Collections;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Wedge _start;
    [SerializeField] private Wedge _end;
    [SerializeField] private float _bendingSpeed;

    private RopeStart _ropeStart;
    private RopeEnd _ropeEnd;

    private void Awake()
    {
        _ropeStart = GetComponentInChildren<RopeStart>();
        _ropeEnd = GetComponentInChildren<RopeEnd>();
    }

    private void OnEnable()
    {
        StartCoroutine(MovingRopeEnds());
    }

    private IEnumerator MovingRopeEnds()
    {
        while (_ropeStart.transform.position != _start.RopeStartPlace.transform.position || _ropeEnd.transform.position != _end.RopeEndPlace.transform.position)
        {
            _ropeStart.transform.position = Vector3.MoveTowards(_ropeStart.transform.position, _start.RopeStartPlace.transform.position, _bendingSpeed * Time.deltaTime);
            _ropeEnd.transform.position = Vector3.MoveTowards(_ropeEnd.transform.position, _end.RopeEndPlace.transform.position, _bendingSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
