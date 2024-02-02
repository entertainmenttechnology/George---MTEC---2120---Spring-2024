using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 ScaleInitial;

    public Vector3 ScaleOver;

    public Vector3 ScaleCurrent;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, ScaleCurrent, .01f);
    }

    void OnMouseOver()
    {
      Debug.Log("Over");
    }

    void OnMouseEnter()
    {
      ScaleCurrent = ScaleOver;
    }

    void OnMouseExit()
    {
      ScaleCurrent = ScaleInitial;
    }

    void OnMouseDown()
    {
      Debug.Log("click");
    }

    IEnumerator FlipCard()
    {
        yield return null;
    }

}
