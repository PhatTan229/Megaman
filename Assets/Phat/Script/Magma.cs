using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HP>(out var hp))
        {
            if (!hp.isImmuneToFire) hp.Die();
        }
    }
}
