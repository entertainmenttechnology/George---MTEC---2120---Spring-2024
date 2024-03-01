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
        GameObject.FindObjectsOfType<InputDetector>()[1].DoBallReset();
    }
}
