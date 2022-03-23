using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class VolcanoStageGameFlow : GameFlow
{
    public FireRainController fireRainController;
    public GameObject magmaSystem;
    public override void CreateBoss()
    {
        base.CreateBoss();
        var dragoon = currentBoss.GetComponent<MagmaDragoon>();
        dragoon.target = hero.transform;
        dragoon.ultimateWeapon = fireRainController;
        Destroy(magmaSystem);
        
    }

    
}
