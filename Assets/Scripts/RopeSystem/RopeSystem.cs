using UnityEngine;

public class RopeSystem : MonoBehaviour
{
    [SerializeField] private PlayerBinding _playerBinding;


    private void OnEnable()
    {
        _playerBinding.PlayerRopeMoved += OnPlayerRopeMoved;
    }

    private void OnDisable()
    {
        _playerBinding.PlayerRopeMoved -= OnPlayerRopeMoved;
    }

    private void OnPlayerRopeMoved()
    {
        if (!_playerBinding.CurrentWedge.IsRopeActive)
        {
            _playerBinding.CurrentWedge.ActivateRope();
        }
    }
}
