using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameFlow gameFlow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameFlow.BlockBossRoom();
        gameFlow.DisableHero();
        gameFlow.ShowWarning();
        Destroy(gameObject);
    }
}
