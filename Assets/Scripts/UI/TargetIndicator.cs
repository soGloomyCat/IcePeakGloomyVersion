using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ArrowColorHandler))]
public class TargetIndicator : MonoBehaviour
{
    [SerializeField] private Image _arrow;
    [SerializeField] private Image _icon;

    private float _hideDistanceClose = 4f;
    private float _hideDistanceFar = 20f;
    private PointTarget _target;
    private ArrowColorHandler _arrowColor;

    private void Awake()
    {
        HideArrow();
        _arrowColor = GetComponent<ArrowColorHandler>();
    }

    private void Update()
    {
        Process();   
    }

    private void Process()
    {
        Vector3 direction = _target.transform.position - transform.position;

        if (direction.magnitude < _hideDistanceClose || direction.magnitude > _hideDistanceFar)
            HideArrow();
        else
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            ShowArrow();
        }

        _icon.transform.rotation = Quaternion.Euler(Vector3.zero);
        _arrowColor.Process(direction.magnitude);
    }

    public void Activate(PointTarget target)
    {
        _target = target;
        _icon.sprite = target.Icon;
        _target.TargetDestroyed += OnTargetDestroy;
        ShowArrow();
        _arrowColor.Init(_arrow, Vector3.Distance(transform.position, _target.transform.position), target.FarColor, target.CloseColor);
    }

    private void ShowArrow()
    {
        _arrow.gameObject.SetActive(true);
    }

    private void HideArrow()
    {
        _arrow.gameObject.SetActive(false);
    }

    private void OnTargetDestroy()
    {
        _target.TargetDestroyed -= OnTargetDestroy;
        Destroy(gameObject);
    }
}
