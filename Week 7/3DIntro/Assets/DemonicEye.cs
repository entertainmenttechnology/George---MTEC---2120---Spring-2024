using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonicEye : MonoBehaviour
{
    bool lookAtPlayer;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameManager.Changed += OnPlayerAnimate;
    }

    // Update is called once per frame
    void Update()
    {
        if(lookAtPlayer)
        {
            transform.LookAt(GameManager.gameManager.player.transform);
        }
    }

    void OnPlayerAnimate(bool isAnimating)
    {
        lookAtPlayer = isAnimating;
    }
}
