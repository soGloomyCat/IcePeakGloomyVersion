using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(Likes))]
public class Survivals : MonoBehaviour, IEnumerable
{
    [SerializeField] private Money _money;

    private Survival[] _survivals;
    private List<Survival> _saved = new List<Survival>();
    private Likes _likes;

    public IReadOnlyList<Survival> Saved => _saved;
    public int Count => _survivals.Length;
    public int SavedCount => _saved.Count;
    public Survival this[int index] => _survivals[index];

    private void Awake()
    {
        _likes = GetComponent<Likes>();
    }

    public IEnumerator GetEnumerator()
    {
        return _survivals.GetEnumerator();
    }

    public void Init()
    {
        _survivals = GetComponentsInChildren<Survival>();

        foreach (Survival survival in _survivals)
            survival.Saved += OnSave;
    }

    private void OnSave(Survival survival)
    { 
        _saved.Add(survival);
    }

    public void AddLikes()
    {
        int currentLikesCount = _saved.Count;
        int result = default;

        foreach (Survival survival in _saved)
        {
            for (int i = 0; i < currentLikesCount; i++)
            {
                if (_likes.TryGetObject(out Like3D like))
                {
                    like.transform.position = survival.transform.position + (Vector3.up * 2.2f);
                    like.gameObject.SetActive(true);
                    like.Move(i, survival.transform);
                    result++;
                }
                else
                {
                    continue;
                }
            }
        }

        _money.Deposit(result);
    }
}
