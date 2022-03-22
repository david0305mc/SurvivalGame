using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UniRx.Triggers;

public class TestUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private UniRxTest timeCounter;
    // Start is called before the first frame update
    void Start()
    {
        //timeCounter.subjectTimer.Subscribe(param => Debug.Log($"{param}"));

        button.OnPointerDownAsObservable()
            .SelectMany(_=>button.UpdateAsObservable())
            .TakeUntil(button.OnPointerUpAsObservable())
            .Subscribe(_ =>
            {
                Debug.Log("pressing");
            });
    }

}
