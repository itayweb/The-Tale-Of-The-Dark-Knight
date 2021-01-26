using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] Image healthBarSlider;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBarSlider.fillAmount = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage){
        currentHealth -= damage;
        healthBarSlider.fillAmount = currentHealth / maxHealth;
        Debug.Log(currentHealth);
        if (currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        Debug.Log("Player died");
    }
}
