using UnityEngine;

public class LikesCollector : MonoBehaviour
{
    [SerializeField] private Transform _canvas;
    [SerializeField] private Money _money;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out LikesGiver likesGiver) && !likesGiver.IsActivated)
        {
            int result = default;
            likesGiver.Activate();

            for (int i = 0, l = likesGiver.Count; i < l; i++)
            {
                Like like = Instantiate(likesGiver.LikeTemplate, _canvas);
                like.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up);
                like.Move(i);
                result++;
            }

            _money.Deposit(result);
        }
    }
}
