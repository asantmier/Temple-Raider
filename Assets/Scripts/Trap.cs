using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Respawn r = other.GetComponent<Respawn>();
        if (r != null)
        {
            r.Die();
        }
    }
}
