using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private AppMetricaObject _appMetricaObject;

    private void Awake()
    {
        _game.Init();
        _appMetricaObject.Init();
        _game.LoadNextScene();
    }
}
