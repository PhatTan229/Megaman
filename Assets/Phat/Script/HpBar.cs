using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SelectionBase]
public class HpBar : MonoBehaviour
{
    public HP hp;
    public Image hpImage;
    public bool dislay;
    // Start is called before the first frame update
    void Start()
    {
        OnHpChange();
        if (!dislay)
        {
            gameObject.SetActive(false);
        }
    }
     public void OnHpChange()
    {
        hpImage.fillAmount = (float)hp.Hp / hp.maxHp;
        if(!dislay)
        {
            Show();
            CancelInvoke();
            Invoke(nameof(Hide),1f);
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
}
