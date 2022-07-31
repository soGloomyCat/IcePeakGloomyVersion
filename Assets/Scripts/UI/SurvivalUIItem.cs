using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SurvivalUIItem : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private GameObject _crossImage;

    private bool _isUsed;

    public bool IsUsed => _isUsed;

    private void Awake()
    {
        transform.localScale = Vector3.zero;
        _crossImage.SetActive(true);
        _iconImage.gameObject.SetActive(false);
    }

    public void Init(float delay)
    {
        transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutElastic).SetDelay(delay);
    }

    public void Activate(Sprite sprite)
    {
        _isUsed = true;
        _crossImage.SetActive(false);
        _iconImage.sprite = sprite;
        _iconImage.gameObject.SetActive(true);
        transform.DOPunchScale(Vector3.one * 0.3f, 0.5f, 8);
    }
}
