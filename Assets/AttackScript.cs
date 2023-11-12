using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public int damage = 1;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        Vector3 RaycastTo = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, RaycastTo, out hit, 4f))
            {
                Debug.Log(hit.collider.gameObject.tag);
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    hit.collider.gameObject.GetComponent<EnemyAiTutorial>().TakeDamage(damage);
                }
            }
            else
            {
                Debug.DrawRay(transform.position, RaycastTo * 4f, Color.red);
            }
        }

    }
}
