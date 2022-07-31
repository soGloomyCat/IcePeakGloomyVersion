using UnityEngine;
using UnityEngine.Events;

public class PointTarget : MonoBehaviour
{
    [SerializeField] private Color _closeColor;
    [SerializeField] private Color _farColor;

    private Sprite _icon;

    public Color CloseColor => _closeColor;

    public Sprite Icon => _icon;

    public Color FarColor => _farColor;

    public event UnityAction TargetDestroyed;

    public void SetIcon(Sprite sprite) => _icon = sprite;

    public void OnTargetDestroy() => TargetDestroyed?.Invoke();
}
