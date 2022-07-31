using UnityEngine;

public abstract class GameLevel : MonoBehaviour
{
    [SerializeField] protected Money _money;
    [SerializeField] protected AppMetricaObject _appMetricaObject;
    [SerializeField] protected Game _game;
}
