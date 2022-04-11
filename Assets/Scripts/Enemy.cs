using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2d;

    private Transform targetDestination;
    [SerializeField] private float speed = 3f;

    [SerializeField] int hp = 4;
    [SerializeField] int damage = 10;

    private Character targetCharacter;

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rigidbody2d.velocity = direction * speed;
    }

    public void SetTarget(Transform target)
    {
        targetDestination = target;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetDestination.gameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        //Debug.Log("Emey Attack");
        if (targetCharacter == null)
        {
            targetCharacter = targetDestination.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp < 1)
        {
            Destroy(gameObject);
        }
    }
}
