using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleTrigger : MonoBehaviour
{
    [SerializeField]
    UnityEvent TriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter.Invoke();
    }
}
