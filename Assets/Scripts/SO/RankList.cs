using UnityEngine;
using System;

[CreateAssetMenu(fileName = "RankList", menuName = "GameAssets/RankList")]
public class RankList : ScriptableObject
{
    [SerializeField] private Rank[] _ranks;

    public Rank this[int index] => _ranks[index];
}

[Serializable]
public struct Rank
{ 
    public string Name;
    public int CategoryPrice;
    public Color Color;
}
