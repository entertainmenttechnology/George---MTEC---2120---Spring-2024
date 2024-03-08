using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float CurrentTime;
    public float TimeForTimer;
    bool isExpired = false;
    public bool isLooping;
    void Start()
    {
        CurrentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;
        if(CurrentTime > TimeForTimer)
        {
            if(!isLooping && !isExpired)
            {
                isExpired = true;
                DoTimeThing();
            }
            if(isLooping)
            {
                DoTimeThing();
                CurrentTime = 0;
            }
        }
    }

    public virtual void DoTimeThing()
    {
        Debug.Log("Timing");
    }
}
