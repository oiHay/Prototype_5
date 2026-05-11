using System;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
