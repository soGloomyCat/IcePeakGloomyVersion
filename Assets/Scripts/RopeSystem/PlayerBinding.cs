using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerBinding : MonoBehaviour
{
    [SerializeField] private PlayerRope _playerRope;
    [SerializeField] private RopeStart _ropeStart;
    [SerializeField] private Button _ropeButton;
    [SerializeField] private Wedge _currentWadge;
    [SerializeField] private float _bendingSpeed;
    [SerializeField] private RopeSystem _ropeSystem;
    [SerializeField] private FinishPlatform _finishPlatform;

    private Wedge _collidedWedge;
    private bool _isRopeMoving = false;

    public Wedge CollidedWedge => _collidedWedge;
    public Wedge CurrentWedge => _currentWadge;

    public event UnityAction PlayerRopeMoved;

    private void Start()
    {
        _ropeStart.transform.position = _currentWadge.RopeStartPlace.position;
    }

    private void OnEnable()
    {
        _finishPlatform.PlayerReached += OnPlatformReached;
    }

    private void OnDisable()
    {
        _finishPlatform.PlayerReached -= OnPlatformReached;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Wedge>(out Wedge wedge))
        {
            _collidedWedge = wedge;

            if (_collidedWedge != _currentWadge)
            {
                _currentWadge = _collidedWedge;

                PlayerRopeMoved?.Invoke();

                if (!_isRopeMoving)
                {
                    StartCoroutine(MovingPlayerRope());
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Wedge>(out Wedge wedge))
        {
            _collidedWedge = null;
        }
    }

    private void OnPlatformReached()
    {
        _playerRope.gameObject.SetActive(false);
    }

    private IEnumerator MovingPlayerRope()
    {
        _isRopeMoving = true;

        while (_ropeStart.transform.position != _currentWadge.RopeStartPlace.position)
        {
            _ropeStart.transform.position = Vector3.MoveTowards(_ropeStart.transform.position, _currentWadge.RopeStartPlace.position, _bendingSpeed * Time.deltaTime);

            yield return null;
        }

        _isRopeMoving = false;
    }
}
