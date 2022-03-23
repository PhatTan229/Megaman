using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaRipple : MonoBehaviour
{
    public MagmaPillar pillar;
    void Start()
    {
        Invoke(nameof(CreateMagmaPillar), 1f);

    }
    private void CreateMagmaPillar()
    {
        Instantiate(pillar, transform.position, transform.rotation);
        Destroy(gameObject);
    }



}
