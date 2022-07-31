using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private FinishPlatform _finishPlatform;

    private float _blend;
    private float _oX;
    private float _oY;

    private void OnEnable()
    {
        _finishPlatform.PlayerReached += OnPlayerReached;
        _finishPlatform.PlayerFinish += OnPlayerFinish;
    }

    private void OnDisable()
    {
        _finishPlatform.PlayerReached -= OnPlayerReached;
        _finishPlatform.PlayerFinish -= OnPlayerFinish;

    }

    private void Update()
    {
        if (_joystick.Direction != Vector2.zero)
        {
            _animator.SetBool(AnimatorPlayer.Bool.IsIdle, false);

            _oX = _joystick.Direction.x;
            _oY = _joystick.Direction.y;
            _blend = Mathf.Abs(_oX) / (Mathf.Abs(_oY) + Mathf.Abs(_oX));

            _animator.SetFloat(AnimatorPlayer.Float.Blend, _blend);
            _animator.SetFloat(AnimatorPlayer.Float.oX, _oX);
            _animator.SetFloat(AnimatorPlayer.Float.oY, _oY);
        }
        else
        {
            _animator.SetBool(AnimatorPlayer.Bool.IsIdle, true);
        }
    }

    private void OnPlayerReached()
    {
        _animator.SetTrigger(AnimatorPlayer.Trigger.FinishReached);
    }

    private void OnPlayerFinish()
    {
        _animator.SetTrigger(AnimatorPlayer.Trigger.LevelComplite);
    }

    public void EnableLoseControlAnimation()
    {
        _animator.SetBool(AnimatorPlayer.Bool.IsLoseControl, true);
    }

    public void DisableLoseControlAnimation()
    {
        _animator.SetBool(AnimatorPlayer.Bool.IsLoseControl, false);
    }

    public static class AnimatorPlayer
    {
        public static class Float
        {
            public const string Blend = nameof(Blend);
            public const string oX = nameof(oX);
            public const string oY = nameof(oY);
        }

        public static class Bool
        {
            public const string IsIdle = nameof(IsIdle);
            public const string IsLoseControl = nameof(IsLoseControl);
        }

        public static class Trigger
        {
            public const string FinishReached = nameof(FinishReached);
            public const string LevelComplite = nameof(LevelComplite);
        }
    }
}
