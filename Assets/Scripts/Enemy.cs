using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2d;

    [SerializeField] private Transform targetDestination;
    [SerializeField] private float speed = 3f;

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rigidbody2d.velocity = direction * speed;
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
        Debug.Log("Attack");
    }
}
