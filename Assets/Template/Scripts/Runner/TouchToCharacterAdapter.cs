using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToCharacterAdapter : MonoBehaviour
{
    public Action<CharacterMoveDirection> RequestDirectionAction { get; set; }

    public void OnSwiped(float _angle)
    {
        CharacterMoveDirection _direction;

        if (Mathf.Abs(_angle) < 45)
        {
            _direction = CharacterMoveDirection.Up;
        }
        else
        {
            _direction = _angle < 0 ? CharacterMoveDirection.Left : CharacterMoveDirection.Right;
        }

        RequestDirectionAction.Invoke(_direction);
    }
}
