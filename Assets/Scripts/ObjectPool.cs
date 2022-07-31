using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected Transform _container;
    [SerializeField] private int _amount;

    protected List<T> _pool = new List<T>();

    protected void Initialize(T template)
    {
        for (int i = 0; i < _amount; i++)
        {
            T item = Instantiate<T>(template, _container);
            item.gameObject.SetActive(false);
            _pool.Add(item);
        }
    }

    public bool TryGetObject(out T result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);
        return result != null;
    }
}
