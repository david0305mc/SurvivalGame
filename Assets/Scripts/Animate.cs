using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{

    [SerializeField] private Animator animator;

    public float horizontal;


    private void Update()
    {
        animator.SetFloat("Horizontal", horizontal);
    }

}
