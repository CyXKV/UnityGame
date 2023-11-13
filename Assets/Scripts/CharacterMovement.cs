using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    private float moveSpeed; 
    private Camera mainCamera;
    public bool hasKey = false;

    public Animator anim;

    private bool isWPressed;
    private bool isAPressed;
    private bool isDPressed;

    void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("В сцене нет активной камеры!");
        }

        moveSpeed = walkSpeed; 
    }

    void Update()
    {
        if (mainCamera == null)
        {
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        isWPressed = Input.GetKey(KeyCode.W);
        isAPressed = Input.GetKey(KeyCode.A);
        isDPressed = Input.GetKey(KeyCode.D);

        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;

        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0;
        cameraForward = cameraForward.normalized;

        Vector3 adjustedMovement = Quaternion.LookRotation(cameraForward) * movement;

        if (adjustedMovement != Vector3.zero)
        {
            anim.SetBool("isWalk", true);
            transform.Translate(adjustedMovement, Space.World);

            
            if (isWPressed)
            {
                anim.SetBool("isLeft", isAPressed);
                anim.SetBool("isRight", isDPressed);
            }
        }
        else
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }

       /* if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && isWPressed)
        {
            if (vertical > 0) 
            {
                anim.SetBool("isRun", true);
                moveSpeed = runSpeed;
            }
            else
            {
                anim.SetBool("isRun", false);
            }
        }
        else
        {
            moveSpeed = walkSpeed;
            anim.SetBool("isRun", false);
        }*/

        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2.0f);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("key"))
                {
                    hasKey = true;
                    Destroy(col.gameObject);
                }
            }
        }*/
    }
}