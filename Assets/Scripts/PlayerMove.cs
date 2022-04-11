using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private Animate animate;
         
    [SerializeField] private float speed = 3;


    private Vector3 movementVector;

    private void Awake()
    {
        movementVector = new Vector3();
    }
    private void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
        animate.horizontal = movementVector.x;

        rigidbody2d.velocity = movementVector * speed;  
    }
}
