using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class COR : MonoBehaviour
{
    [SerializeField] float time = 3;
    [SerializeField] bool go;

    Coroutine timerCorutine;

    void Start()
    {
      timerCorutine = StartCoroutine(Timer(time));
        StartCoroutine(storytime());
        StartCoroutine(WaitAction());
    }

    void Update()
    {
        //time -= Time.deltaTime;
        //if (time <= 0)
        //{
        //    print("ding");
        //    time = 3;
        //}
    }

    IEnumerator Timer(float time)
    {
        for (; ; )
        {
            yield return new WaitForSeconds(time);
            print("ding");
        }
    }
    IEnumerator storytime()
    {
        print("welcome...");
        yield return new WaitForSeconds(1);
        print("welcome to the new world");
         yield return new WaitForSeconds(1);
        print("time to die.");

        StopCoroutine(timerCorutine);

    }

    IEnumerator WaitAction()
    {
        yield return new WaitUntil(() => go);
            print("go");
        yield return null;
    }
}
