using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LeftPaddle;
    public GameObject RightPaddle;
    public GameObject Ball;

    
    public float ForceAmt = 4f;

    private bool BallIsReset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(BallIsReset)
            {
                BallIsReset = false;
                Ball.GetComponent<Rigidbody2D>().isKinematic = false;
                
            }
        }

        if(Input.GetKey(KeyCode.A))
        {
            
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            
        }
    }

    public void DoBallReset()
    {
        BallIsReset = true;
    }
}
