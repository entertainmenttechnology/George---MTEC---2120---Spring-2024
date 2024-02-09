using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    public float speed = 2f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float XMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float YMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector2 move = new Vector2(XMove, YMove);
        transform.Translate(move);

        animator.SetFloat("X", XMove);
        animator.SetFloat("Y", YMove);

    }
}
