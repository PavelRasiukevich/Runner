using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] UnityEvent<float> swipeAction;

    Vector2 startPosition;

    float CalculateAngle(Vector2 _startPos, Vector2 _endPos)
    {
        _endPos -= _startPos;
        float _angle = Vector2.SignedAngle(_endPos, Vector2.up);
        return _angle;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        startPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        float _angle = CalculateAngle(startPosition, eventData.position);
        swipeAction.Invoke(_angle);
    }

}
