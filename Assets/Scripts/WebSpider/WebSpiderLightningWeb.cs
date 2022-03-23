using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpiderLightningWeb : MonoBehaviour
{
    public Transform target;
    public void Disapear()
    {
        Destroy(gameObject, 0.167f);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
