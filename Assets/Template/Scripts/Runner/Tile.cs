using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] float tileLength;

    public float LocalPosition
    {
        get => transform.localPosition.z;

        set
        {
            var _pos = transform.localPosition;
            _pos.z = value;
            transform.localPosition = _pos;
        }
    }

    public float TileLength { get => tileLength; }
}
