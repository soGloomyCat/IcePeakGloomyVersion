using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Game", menuName = "GameAssets/Game")]
public class Game : ScriptableObject
{
    [SerializeField] private int _scenesCount;

    public const string LEVEL_NUMBER_KEY = "icePeak/currentLevelNumber";
    public const string LEVEL_INDEX_KEY = "icePeak/currentLevelIndex";
    public const string MONEY_KEY = "icePeak/money";

    /* INTEGRATIONS */
    public const string IS_FIRST_START = "icePeak/isFirstStart";
    public const string REG_DAY = "icePeak/regDay";
    public const string SESSION_COUNT = "icePeak/sessionCount";

    /*RANKS*/
    public const string RANK_KEY = "icePeak/rank";
    public const string CATEGORY_KEY = "icePeak/category";
    public const string CURRENTRANK_VALUE_KEY = "icePeak/currentRankValue";

    private int _currentLevelNumber;
    private int _currentLevelIndex;

    public int CurrentLevelNumber => _currentLevelNumber;

    public void Init()
    {
        _currentLevelNumber = PlayerPrefs.GetInt(LEVEL_NUMBER_KEY, 1);
        _currentLevelIndex = PlayerPrefs.GetInt(LEVEL_INDEX_KEY, 1);
        
    }

    public void SaveLevelNumber()
    {
        _currentLevelNumber++;
        PlayerPrefs.SetInt(LEVEL_NUMBER_KEY, _currentLevelNumber);

        _currentLevelIndex++;

        if (_currentLevelIndex > _scenesCount)
            _currentLevelIndex = 1;

        
        PlayerPrefs.SetInt(LEVEL_INDEX_KEY, _currentLevelIndex);
    }

    private string GetSceneName()
    {
        return $"Level {_currentLevelIndex}";
    }

    public void LoadNextScene()
    {
        string currentScene = GetSceneName();
        SceneManager.LoadScene(currentScene);
    }
}
