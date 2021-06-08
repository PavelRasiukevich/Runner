using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrigger : MonoBehaviour
{
    public bool IsGrounded { get; set; }

    private void OnTriggerStay(Collider other)
    {
        IsGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        IsGrounded = false;
    }
}
