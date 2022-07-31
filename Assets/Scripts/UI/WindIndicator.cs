using UnityEngine;

public class WindIndicator : MonoBehaviour
{
    [SerializeField] private CanvasGroup _panel;
    [SerializeField] private float _transparency = .2f;

    public void Activate()
    {
        _panel.alpha = _transparency;
    }

    public void Deactivate()
    {
        _panel.alpha = 0;
    }
}

