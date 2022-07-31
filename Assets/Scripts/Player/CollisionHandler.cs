using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(PlayerBinding))]
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _gap = 1;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private PlayerBinding _playerBinding;
    private Rigidbody _rigidbody;
    private bool _isMovingToWedge = false;


    public event UnityAction StoneCollision;
    public event UnityAction LastWedgeReached;

    private void Awake()
    {
        _playerBinding = GetComponent<PlayerBinding>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamper damper))
        {
            StoneCollision?.Invoke();

            if (!_isMovingToWedge)
                StartCoroutine(MoveToWedge(_playerBinding.CurrentWedge.transform));
        }
    }

    private IEnumerator MoveToWedge(Transform target)
    {
        _isMovingToWedge = true;

        _playerAnimation.EnableLoseControlAnimation();

        _rigidbody.velocity = Vector3.zero;

        Vector3 direction = (target.position - transform.position).normalized;

        while (Vector3.Distance(transform.position, target.position) > _gap)
        {
            //transform.Translate(direction * Time.deltaTime * _speed);
            Vector3 step = direction * Time.fixedDeltaTime * _speed;
            _rigidbody.MovePosition(transform.position + step);
            yield return new WaitForFixedUpdate();
        }

        LastWedgeReached?.Invoke();

        _rigidbody.velocity = Vector3.zero;

        _playerAnimation.DisableLoseControlAnimation();
        _isMovingToWedge = false;
    }
}
