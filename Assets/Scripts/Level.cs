using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Ranking))]
public class Level : GameLevel
{
    [SerializeField] private Player _player;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Cameras _cameras;
    [SerializeField] private Survivals _survivals;
    [SerializeField] private UIManager _uIManager;
    [SerializeField] private StoneThrower[] _stoneThrowers;

    private Ranking _ranking;

    private void Awake()
    {
        _ranking = GetComponent<Ranking>();
    }

    private void OnEnable()
    {
        _finishPlatform.PlayerReached += OnPlayerReachFinishPlatform;
        _finishPlatform.PlayerFinish += OnPlayerFinish;
        _ranking.RankingFinished += OnRankingFinish;
    }

    private void OnDisable()
    {
        _finishPlatform.PlayerReached -= OnPlayerReachFinishPlatform;
        _finishPlatform.PlayerFinish -= OnPlayerFinish;
        _ranking.RankingFinished -= OnRankingFinish;
    }

    private void Start()
    {
        _money.Init();
        _cameras.Activate(CameraType.Player);
        _survivals.Init();
        _player.Init();
        _uIManager.Init(_survivals);
        _ranking.Init();
        _appMetricaObject.LevelStart(_game.CurrentLevelNumber);

        if (_stoneThrowers.Length > 0)
        {
            for (int i = 0; i < _stoneThrowers.Length; i++)
            {
                _stoneThrowers[i].Init(_player);
            }
        }
    }

    private void OnPlayerReachFinishPlatform()
    {
        _cameras.Activate(CameraType.Finisher);
        _finishPlatform.PlaceSaved(_survivals.Saved);
    }

    private void OnPlayerFinish()
    {
        _survivals.AddLikes();
        _ranking.Calculate();
    }

    private void OnRankingFinish()
    {
        FinishLevel();
    }

    private void FinishLevel()
    {
        _appMetricaObject.LevelComplete(_game.CurrentLevelNumber, _money.Value);
        _game.SaveLevelNumber();
        _uIManager.OnLevelFiinsh();
    }

    public void OnNextLevelButtonClick()
    {
        _game.LoadNextScene();
    }
}
