using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed = 1;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private Rigidbody _rigidbody;
    private bool _isActive;
    private float _windInfluence;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
            _rigidbody.velocity = Vector3.zero;

        if (!_isActive)
            return;

        if (_windInfluence == 0)
            _playerAnimation.DisableLoseControlAnimation();

        Vector3 step = _joystick.Direction * Time.fixedDeltaTime * _speed;
        step += (Vector3.right * _windInfluence);

        _rigidbody.MovePosition(transform.position + step);
        _windInfluence = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Wind wind))
        {
            _playerAnimation.EnableLoseControlAnimation();
            _windInfluence = (int)wind.Direction * wind.Power;
        }
    }

    public void DisablePhysics()
    {
        Disable();
        //_joystick.gameObject.SetActive(false);
        _rigidbody.isKinematic = true;
    }

    public void EnablePhysics()
    {
        Enable();
        //_joystick.gameObject.SetActive(true);
        _rigidbody.isKinematic = false;
    }

    public void Enable() => _isActive = true;

    public void Disable() => _isActive = false;
}
