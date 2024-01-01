using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Test : MonoBehaviour
{
    public SequenceEventExecutor executor;
    public SequenceEventExecutor newExecutor;
    public bool canReturn = false;
    public bool once = true;
    public int a = 500;

    private void Start()
    {
        executor.Init(OnFinishedEvent);
        
        Debug.Log("start!");
        executor.Execute();

    }
    // Update is called once per frame
    void Update()
    {
        //canReturn && once
        //Input.GetKeyDown(KeyCode.Y)
        if (Input.GetKeyDown(KeyCode.Y))
        {
            newExecutor.Init(OnFinishedEvent2);
            newExecutor.Execute();
            once = false;
            a --;
            Debug.Log(33333);
        }
    }

    void OnFinishedEvent(bool success)
    {
        canReturn = true;
        // newExecutor.Init(OnFinishedEvent2);
        // newExecutor.Execute();
        Debug.Log("Success!!!");
    }
     
     
     
     
     void OnFinishedEvent2(bool success)
    {
        Debug.Log("Success222!!!");
    }
}
