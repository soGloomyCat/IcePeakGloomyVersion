using UnityEngine;

public class Likes : ObjectPool<Like3D>
{
    [SerializeField] private Like3D _likeTemplate;

    private void Awake()
    {
        Initialize(_likeTemplate);
    }
}
