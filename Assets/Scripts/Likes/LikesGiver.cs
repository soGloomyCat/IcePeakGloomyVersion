using UnityEngine;

public class LikesGiver : MonoBehaviour
{
    [SerializeField] private int _likesCount;
    [SerializeField] private Like _likeTemplate;

    public bool IsActivated { get; private set; }
    public int Count => _likesCount;
    public Like LikeTemplate => _likeTemplate;

    public void Activate()
    { 
        IsActivated = true;
    }
}
