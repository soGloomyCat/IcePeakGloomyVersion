using UnityEngine.UI;
using UnityEngine;

public class ArrowColorHandler : MonoBehaviour
{
    private Color _farColor;
    private Color _closeColor;
    private Image _arrow;
    private float _maxDistance;

    public void Init(Image arrow, float maxDistance, Color farColor, Color closeColor)
    {
        _arrow = arrow;
        _maxDistance = maxDistance;
        _farColor = farColor;
        _closeColor = closeColor;
    }

    public void Process(float currentDistance)
    {
        float lerp = currentDistance / _maxDistance;
        _arrow.color = Color.Lerp(_closeColor, _farColor, lerp);
    }
}
