using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestory : MonoBehaviour
{
    [SerializeField] GameObject healthPickUp;
    [SerializeField] [Range(0, 1)] float change = 1f;

    private void OnDestroy()
    {
        if (Random.value < change)
        {
            Transform t = Instantiate(healthPickUp).transform;
            t.position = transform.position;
        }
    }
}
