using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine;
using DG.Tweening;

public class SimpleControl : MonoBehaviour
{
    public GameManager gm;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private Camera MainCamera;
    private bool IsAnimating = false;
    bool IsRightClick = false;
    private Vector3 origScale;
    private void Awake()
    {
        MainCamera = Camera.main;

        GameManager.gameManager.score++;
    }
    private void Start()
    {
        origScale = transform.localScale;
        controller = gameObject.GetComponent<CharacterController>();
        
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        bool isRightClick;
        if(Input.GetButtonDown("Fire1"))
        {
            if(!IsAnimating)
            {
                IsAnimating = true;
                isRightClick = false;
                transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), .4f)
                    .SetLoops(2, LoopType.Yoyo)
                    .SetEase(Ease.InOutQuad)
                    .OnComplete(() => { DoComplete(isRightClick); });
            }

        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (!IsAnimating)
            {
                IsAnimating = true;
                isRightClick = true;
                transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), .4f)
                    .SetLoops(2, LoopType.Yoyo)
                    .SetEase(Ease.InOutQuad)
                    .OnComplete(() => { DoComplete(isRightClick); });
            }

        }

        MainCamera.transform.LookAt(transform.position);
    }

    void DoComplete(bool isRightClick)
    {
        Debug.Log("I'm Here!");
        IsAnimating = false;
        if(isRightClick)
        {
            GetComponent<MeshRenderer>().material.DOColor(Color.red, .3f);
        }
        else
        {
            GetComponent<MeshRenderer>().material.DOColor(Color.blue, .3f);
        }
    }
    public bool isAnimating()
    {
        return IsAnimating;
    }
}