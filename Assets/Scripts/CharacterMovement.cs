using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    private Camera mainCamera;
    public Animator anim;

    void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("There is no active Camera in the scene!");
        }
    }

    void Update()
    {
        if (mainCamera == null)
        {
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;

        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0;
        cameraForward = cameraForward.normalized;

        Vector3 adjustedMovement = Quaternion.LookRotation(cameraForward) * movement;

        if (adjustedMovement != Vector3.zero)
        {
            anim.SetBool("isWalk", true);
            transform.Translate(adjustedMovement, Space.World);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }
    }

}