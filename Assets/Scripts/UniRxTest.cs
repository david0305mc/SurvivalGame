using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Subject<string> subject = new Subject<string>();
        subject.Subscribe(msg => Debug.Log($"Subscribe1 {msg}"));
        subject.Subscribe(msg => Debug.Log($"Subscribe2 {msg}"));
        subject.Subscribe(msg => Debug.Log($"Subscribe3 {msg}"));

        subject.OnNext("Hello");
        subject.OnNext("Hi");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
