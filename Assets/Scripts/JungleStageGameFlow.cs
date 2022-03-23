using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleStageGameFlow : GameFlow
{
    public GameObject bossDoor;
    public LeafController treeBranch;
    public override void CallTheBoss()
    {
        base.CallTheBoss();
        treeBranch.CreateLeaf(bossEntrance.position, 20);
    }
    public override void CreateBoss()
    {
        base.CreateBoss();
        var spider = currentBoss.GetComponent<WebSpider>();
        spider.target = hero.transform;
        spider.treeBranch = treeBranch;
    }

    public override void BlockBossRoom()
    {
        base.BlockBossRoom();
        var constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        bossDoor.AddComponent<Rigidbody2D>().constraints = constraints;              
    }
}
