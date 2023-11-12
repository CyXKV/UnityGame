using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int Health = 5;
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
