using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(TargetArrowsHandler))]
[RequireComponent(typeof(CollisionHandler))]

public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private TargetArrowsHandler _targetArrowsHandler;
    private CollisionHandler _collisionHandler;
    private Collider _collider;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _targetArrowsHandler = GetComponent<TargetArrowsHandler>();
        _collisionHandler = GetComponent<CollisionHandler>();
        _collider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        _collisionHandler.StoneCollision += OnStoneCollision;
        _collisionHandler.LastWedgeReached += OnLastWedgeReached;
    }

    private void OnDisable()
    {
        _collisionHandler.StoneCollision -= OnStoneCollision;
        _collisionHandler.LastWedgeReached -= OnLastWedgeReached;
    }

    public event UnityAction CheckPointPlaced;

    public void Init()
    {
        _playerMover.Enable();
        _targetArrowsHandler.Init();
    }

    public void DisablePhysics()
    {
        _collider.enabled = false;
        _playerMover.DisablePhysics();
    }

    public void EnablePhysics()
    {
        _collider.enabled = true;
        _playerMover.EnablePhysics();
    }

    public void PlaceCheckPoint()
    {
        CheckPointPlaced?.Invoke();
    }

    public void CreateArrow(PointTarget target)
    {
        _targetArrowsHandler.CreateArrow(target);
    }

    private void OnStoneCollision()
    {
        DisablePhysics();
    }

    private void OnLastWedgeReached()
    {
        EnablePhysics();
    }
}
