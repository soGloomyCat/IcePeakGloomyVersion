using UnityEngine;

public class Wedge : MonoBehaviour
{
    [SerializeField] private Rope _wedgeRope;
    [SerializeField] private Rope _secondWedgeRope;
    [SerializeField] private bool _isRopeActive;

    private Resizer _resizer;
    private RopeStartPlace _ropeStartPlacel;
    private RopeEndPlace _ropeEndPlacel;
    private float _resizeTime = 0.4f;
    private float _normalSize = 1f;


    public Transform RopeStartPlace => _ropeStartPlacel.transform;
    public Transform RopeEndPlace => _ropeEndPlacel.transform;
    public bool IsRopeActive => _isRopeActive;

    private void Awake()
    {
        _resizer = GetComponentInChildren<Resizer>();
        _ropeStartPlacel = GetComponentInChildren<RopeStartPlace>();
        _ropeEndPlacel = GetComponentInChildren<RopeEndPlace>();

        if (!_isRopeActive)
        {
            _resizer.gameObject.SetActive(false);
        }
    }

    public void ActivateRope()
    {
        _isRopeActive = true;

        _resizer.gameObject.transform.localScale = Vector3.zero;

        _resizer.gameObject.SetActive(true);

        _resizer.Resize(_resizeTime, _normalSize);

        _wedgeRope.gameObject.SetActive(true);

        if (_secondWedgeRope != null)
            _secondWedgeRope.gameObject.SetActive(true);
    }
}
