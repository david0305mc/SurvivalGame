using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class TestUI : MonoBehaviour
{

    [SerializeField] private UniRxTest timeCounter;
    // Start is called before the first frame update
    void Start()
    {
        timeCounter.subjectTimer.Subscribe(param => Debug.Log($"{param}"));
        //timeCounter.eventTimer += (param) =>
        //{
        //    Debug.Log(param.ToString());
        //};
    }

}
