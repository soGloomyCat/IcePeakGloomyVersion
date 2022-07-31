using UnityEngine;

[CreateAssetMenu(fileName = "StonesHolder", menuName = "GameAssets/StonesHolder")]
public class StonesHolder : ScriptableObject
{
    [SerializeField] private Stone[] _stones;

    public Stone GetRandomStone()
    {
        return _stones[Random.Range(0, _stones.Length)];
    }
}
