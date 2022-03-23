using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HP : MonoBehaviour
{
    [SerializeField]protected Behaviour[] disableOnDeads_Component;
    [SerializeField] protected SpriteRenderer disableOnDeads_SpriteRenderer;
    [SerializeField] protected List<Transform> explosionPosition;
    public int maxHp;
    private int hpValue;   
    public UnityEvent onDie;
    public UnityEvent onHpChange;
    public VFXList dieAnim;
    public bool isPlayer;
    public bool isBoss;
    public int explosionCount;
    public float nextExplsionTime;
    public Animator anim;
    public bool isImmuneToFire;
    public int Hp
    {
        get { return hpValue; }
        protected set
        {
            hpValue = value;
            onHpChange?.Invoke();
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        Hp = maxHp;
    }


    // Update is called once per frame
    public virtual void TakeDamage(int damge)
    {
        Hp -= damge;
        
        if(Hp<=0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        if(isPlayer || isBoss)
        {
            anim.SetBool("Die", true);
            foreach (var component in disableOnDeads_Component)
            {
                component.enabled = false;                
            }
            StartCoroutine(PlayDeathAnimation());
        }
        else
        {
            Destroy(gameObject);
            var g = Instantiate(dieAnim.vfxPrefab[0], transform.position, transform.rotation);
            Destroy(g, dieAnim.vfxClip[0].length);
        }       
        onDie.Invoke();
    }

    protected IEnumerator PlayDeathAnimation()
    {
        int i = 0;
        while (i < explosionCount)
        {
            var randomExposionPosition = Random.Range(0, explosionPosition.Count);
            var randomExplosionPrfeab = Random.Range(9, 11);
            var x = VFXPlayer.PlayAnimation(dieAnim.vfxPrefab[randomExplosionPrfeab], explosionPosition[randomExposionPosition].position, dieAnim.vfxPrefab[randomExplosionPrfeab].transform.rotation);
            Destroy(x, dieAnim.vfxClip[randomExplosionPrfeab].length);
            yield return new WaitForSeconds(nextExplsionTime);
            i++;
            if (i == 10)
            {
                anim.enabled = false;
                disableOnDeads_SpriteRenderer.enabled = false;
            }
        }

    }
}
