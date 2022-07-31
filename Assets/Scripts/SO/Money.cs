using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Money", menuName = "GameAssets/Money")]
public class Money : ScriptableObject
{
    [SerializeField] private int _value;

    private int _valueAtStart;

    public int Value => _value;
    public int GainedMoney => _value - _valueAtStart;

    public event UnityAction<int, int> MoneyChanged;

    public void Init()
    {
        _value = PlayerPrefs.GetInt(Game.MONEY_KEY, 0);
        _valueAtStart = _value;
        FireEvent(_value);
    }

    public void Deposit(int amount)
    {
        int old = _value;
        _value += amount;
        FireEvent(old);
    }

    public void Deposit()
    {
        int old = _value;
        _value += 1;
        FireEvent(old);
    }

    public bool TryWithdraw(int amount)
    {
        if (amount <= _value)
        {
            int old = _value;
            _value -= amount;
            FireEvent(old);
            return true;
        }

        return false;
    }

    private void FireEvent(int old)
    {
        MoneyChanged?.Invoke(old, _value);
        PlayerPrefs.SetInt(Game.MONEY_KEY, _value);
    }
}
