using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;
    

    [SerializeField] private PlayerMove playerMove;
    [SerializeField] Vector2 whipAttackSize = new Vector2(4, 2);
    [SerializeField] int whipDamage = 1;
    public float timeToAttack = 4f;
    float timer;
         
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack(); 
        }
            
    }

    private void Attack()
    {
        timer = timeToAttack;
        if (playerMove.lastHorizontalVector > 0)
        {
            rightWhipObject.SetActive(true);
            var colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
            
        }
        else
        {
            leftWhipObject.SetActive(true);
            var colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        foreach (var item in colliders)
        {

            var enemy = item.GetComponent<IDamageable>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
        }
    }
}
