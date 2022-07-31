using UnityEngine;

public class StoneThrower : MonoBehaviour
{
    [SerializeField] private Vector2 _bounds;
    [SerializeField] private float _interval;
    [SerializeField] private StonesHolder _holder;

    private Player _player;
    private bool _isActive;
    private float _bufferTime;

    public void Init(Player player)
    {
        _player = player;
        _isActive = true;
    }

    private void Update()
    {
        if (_isActive)
            Timer();
    }

    private void Timer()
    {
        _bufferTime += Time.deltaTime;

        if (_bufferTime >= _interval)
        {
            _bufferTime = 0;
            Tick();
        }
    }

    private void Tick()
    {
        if (PlayerInZone())
        {
            Stone stone = Instantiate(_holder.GetRandomStone(), GetPosition(), Quaternion.identity, transform);
            //_player.CreateArrow(stone);
            stone.Move();
        }
    }

    private bool PlayerInZone()
    {
        return _player.transform.position.y > _bounds.x && _player.transform.position.y < _bounds.y;
    }

    private Vector3 GetPosition()
    {
        return new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
