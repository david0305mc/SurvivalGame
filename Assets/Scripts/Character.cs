using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] StatusBar hpBar;
    public int maxHP = 1000;
    public int currHP = 1000;

    public void TakeDamage(int damage)
    {
        currHP -= damage;
        if (currHP <= 0)
        {
            currHP = 0;
            Debug.Log("hero dead");
        }
        hpBar.SetState(currHP, maxHP);
    }

    public void Heal(int amount)
    {
        if (currHP <= 0)
            return;
        currHP += amount;
        if (currHP > maxHP)
        {
            currHP = maxHP;
        }
    }
}
