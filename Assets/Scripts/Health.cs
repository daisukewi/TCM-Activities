using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int currentHealth;

    [SerializeField]
    int maxHealth = 20;

    public int MaxHealth
    {
        get { return maxHealth; }
        private set { maxHealth = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    public void ApplyDamage(int damageAmount)
    {
        if (damageAmount < 0)
        {
            Debug.LogError("Cannot apply negative damange");
            return;
        }

        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);

        // If currentHealth == 0 -> Die() ?
        if (currentHealth <= 0)
        {
            Debug.Log(transform.name + " has died!!");
        }
    }
}
