using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    public PlayerHP hero;
    public float bossDelay;
    public float battleDelay;
    public float showWaringTime;
    public AudioSource stageThemeDirector;
    public AudioSource bossThemeDirector;
    
    public Transform bossRoomBlocker;
    public WarningCanvas warningCanvas;
    public EnemyHp bossPrefab;
    public Transform bossEntrance;
    public HpBar bossHpCanvas;

    protected EnemyHp currentBoss;
    protected Animator bossAnimator;
    protected Movement movement;
    protected Dash dash;
    protected WallMove wallMove;
    protected Attack attack;
    protected ChargeAttack chargeAttack;
    protected Animator animator;
    public virtual void BlockBossRoom()
    {
        bossRoomBlocker.gameObject.SetActive(true);
    }
    public void ShowWarning()
    {
        stageThemeDirector.Stop();
        warningCanvas.gameObject.SetActive(true);
        Invoke(nameof(HideWarning), showWaringTime);
    }
    private void HideWarning()
    {
        warningCanvas.gameObject.SetActive(false);
        CallTheBoss();
    }
    public virtual void CallTheBoss()
    {
        Invoke(nameof(CreateBoss), bossDelay);
    }
    public virtual void CreateBoss()
    {
        currentBoss = Instantiate(bossPrefab, bossEntrance.position, Quaternion.identity);
        bossHpCanvas.hp = currentBoss;
        currentBoss.onHpChange.AddListener(bossHpCanvas.OnHpChange);
        bossHpCanvas.gameObject.SetActive(true);
        currentBoss.onDie.AddListener(DisableHero);
        Invoke(nameof(StartBattle), battleDelay);

    }
    public void DisableHero()
    {
        movement = hero.GetComponent<Movement>();
        dash = hero.GetComponent<Dash>();
        wallMove = hero.GetComponent<WallMove>();
        attack = hero.GetComponent<Attack>();
        chargeAttack = hero.GetComponent<ChargeAttack>();
        animator = hero.GetComponent<Animator>();
        movement.enabled = false;
        dash.enabled = false;
        wallMove.enabled = false;
        attack.enabled = false;
        chargeAttack.enabled = false;
        animator.SetBool("OnGround", true);
        animator.SetBool("Waiting", true);
        hero.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    public void StartBattle()
    {
        ActiveBoss();
        ActiveHero();
        bossThemeDirector.Play();
    }
    private void ActiveBoss()
    {
        currentBoss.GetComponent<Animator>().SetTrigger("Start");
    }
    public void ActiveHero()
    {
        movement.enabled = true;
        dash.enabled = true;
        wallMove.enabled = true;
        attack.enabled = true;
        chargeAttack.enabled = true;
        animator.SetBool("Waiting", false);
        // animator.enabled = true;
    }
    public void BossWin()
    {
        bossAnimator = bossPrefab.GetComponent<Animator>();
        bossAnimator.SetBool("Win", true);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
