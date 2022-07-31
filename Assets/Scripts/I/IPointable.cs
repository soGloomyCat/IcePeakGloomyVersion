using UnityEngine;
using UnityEngine.Events;

public interface IPointable
{
    Transform Transform { get; }

    event UnityAction TargetDestroyed;
}
