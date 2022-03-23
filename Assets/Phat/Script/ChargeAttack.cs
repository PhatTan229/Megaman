using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttack : MonoBehaviour
{
    public float chargeTime;
    public Attack attack;
    [System.NonSerialized] public int chargeLevel;
    public GameObject bullet;
    public Movement move;
    public GameObject shootVFX;
    public VFXList x_VFX;
    public GameObject energySpawn;
    private Vector3 energySpawnPosition;
    private GameObject chargeVFX_1;
    private GameObject chargeVFX_2;

    // Start is called before the first frame update
    void Start()
    {
        x_VFX = GetComponent<VFXList>();
        chargeLevel = 0;
        attack = GetComponent<Attack>();
        move = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        energySpawnPosition = energySpawn.transform.position;
        chargeLevel = 0;
        if (Input.GetKey(KeyCode.C))
        {
            chargeTime += Time.deltaTime;

            if (chargeTime > 1 && chargeTime < 2)
            {            
                chargeLevel = 1;                
            }
            if (chargeTime > 2)
            {
                chargeLevel = 2;
            }
            attack.anim.SetInteger("ChargeLV", chargeLevel);
            ChangeBullet();
        }
        PlayVFX();
        if(Input.GetKeyUp(KeyCode.C) && chargeTime >= 1 )
        {            
            if(move.onGround && move.Axist == 0)
            {
                attack.anim.SetTrigger("ChargeShoot");              
            }
            else
            {
                StartCoroutine(attack.Shoot());
            }           
            chargeTime = 0;
            Destroy(chargeVFX_1);
            Destroy(chargeVFX_2);
        }
        
    }
    private void PlayVFX()
    {
        switch(chargeLevel)
        {
            case 1:
                if (chargeVFX_1 == null)
                {
                    chargeVFX_1 = VFXPlayer.PlayAnimation(x_VFX.vfxPrefab[6], energySpawnPosition, x_VFX.vfxPrefab[6].transform.rotation);
                    chargeVFX_1.transform.SetParent(gameObject.transform);
                }
                else
                {
                    Destroy(chargeVFX_1, x_VFX.vfxClip[6].length);
                }
                break;
            case 2:
                if (chargeVFX_1 == null && chargeVFX_2 == null)
                {
                    chargeVFX_1 = VFXPlayer.PlayAnimation(x_VFX.vfxPrefab[6], energySpawnPosition, x_VFX.vfxPrefab[6].transform.rotation);
                    chargeVFX_2 = VFXPlayer.PlayAnimation(x_VFX.vfxPrefab[7], energySpawnPosition, x_VFX.vfxPrefab[7].transform.rotation);
                    chargeVFX_1.transform.SetParent(gameObject.transform);
                    chargeVFX_2.transform.SetParent(gameObject.transform);
                }
                else
                {
                    Destroy(chargeVFX_1, x_VFX.vfxClip[6].length);
                    Destroy(chargeVFX_2, x_VFX.vfxClip[7].length);
                }
                break;
            default: break;
        }

    }
    private void ChangeBullet()
    {
        switch (chargeLevel)
        {
            case 0:
                bullet = attack.bullet;
                shootVFX = x_VFX.vfxPrefab[0];
                break;
            case 1:
                bullet = attack.bulletLV1;
                shootVFX = x_VFX.vfxPrefab[1];
                break;
            case 2:
                bullet = attack.bulletLV2;
                shootVFX = x_VFX.vfxPrefab[2];
                break;
            default: break;
        }
    }
}
