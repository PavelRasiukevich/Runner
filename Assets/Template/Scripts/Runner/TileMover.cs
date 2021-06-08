using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMover : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] List<Tile> listOfTiles;

    public bool IsMoving { get; set; }
    public float Distance { get; private set; }

    private void Update()
    {
        if (IsMoving)
        {
            float _deltaPosition = -speed * Time.deltaTime;

            Distance += Mathf.Abs(_deltaPosition);

            for (int i = 0; i < listOfTiles.Count; i++)
            {
                var _tile = listOfTiles[i];

                _tile.LocalPosition += _deltaPosition;

                if (_tile.LocalPosition < -_tile.TileLength)
                {
                    var _lastTile = listOfTiles[listOfTiles.Count - 1];

                    _tile.LocalPosition = _lastTile.LocalPosition + _tile.TileLength;

                    listOfTiles.RemoveAt(i);
                    listOfTiles.Add(_tile);

                    i--;
                }
            }
        }
    }
}
