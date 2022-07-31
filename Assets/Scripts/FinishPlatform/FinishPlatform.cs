using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class FinishPlatform : MonoBehaviour
{
    [SerializeField] private Stepway _stepway;
    [SerializeField] private FirePlace _firePlace;

    public event UnityAction PlayerReached;
    public event UnityAction PlayerFinish;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            HandlePlayer(player);
        }
    }

    private void HandlePlayer(Player player)
    {
        PlayerReached?.Invoke();
        player.DisablePhysics();
        _stepway.MovePlayer(player.transform, OnStepwayFinish);
    }

    private void OnStepwayFinish()
    {
        PlayerFinish?.Invoke();
    }

    public void PlaceSaved(IReadOnlyList<Survival> saved)
    {
        _firePlace.PlaceSaved(saved);
    }
}
