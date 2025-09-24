using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : MonoBehaviour
{
    [Header("Where to teleport the ball")]
    public Transform target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            other.transform.position = target.position;
        }
    }
}
