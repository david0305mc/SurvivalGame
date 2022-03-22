using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxTest : MonoBehaviour
{
    public Subject<int> subjectTimer = new Subject<int>();

    void Start()
    {
        //Observable.EveryUpdate()
        //    .Where(_ => Input.GetMouseButtonDown(0))
        //    .Select(_ => Input.mousePosition)
        //    .Subscribe(pos => Debug.Log($"ClickMouse {pos}"));

        Observable.FromCoroutineValue<int>(MyCoroutine)
            .Subscribe(
            x => Debug.Log($"OnNext {x}"),
            () => Debug.Log("OnCompleted")
            ).AddTo(gameObject);
    }

    private IEnumerator MyCoroutine()
    {
        Debug.Log("Start Coroutine");

        for (int i = 0; i < 5; i++)
        {
            yield return i;
        }
        //yield return new WaitForSeconds(3.0f);
        Debug.Log("End Coroutine");
    }

    private IEnumerator TimerTest()
    {
        int time = 1;
        while (time < 100)
        {
            subjectTimer.OnNext(time);
            //eventTimer(time);
            time++;
            yield return new WaitForSeconds(1);
        }
    }


    private void SubjectTest()
    {
        Subject<string> subject = new Subject<string>();
        subject.Subscribe(msg => Debug.Log($"Subscribe1 {msg}"));
        subject.Subscribe(msg => Debug.Log($"Subscribe2 {msg}"));
        subject.Subscribe(msg => Debug.Log($"Subscribe3 {msg}"));

        subject.OnNext("Hello");
        subject.OnNext("Hi");
    }
}
