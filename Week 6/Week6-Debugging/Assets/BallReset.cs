using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BallResetPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        other.transform.position = BallResetPosition.transform.position;
        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        InputDetector[] Detectors = GameObject.FindObjectsOfType<InputDetector>();
        if(Detectors.Length > 0)
        {
            GameObject.FindObjectsOfType<InputDetector>()[0].DoBallReset();
        }
        else
        {
            Debug.LogWarning("Hey couldn't find the indut detector");
        }
    }
}
