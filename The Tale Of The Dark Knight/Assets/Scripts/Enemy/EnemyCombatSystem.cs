using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatSystem : MonoBehaviour
{
    [SerializeField] PlayerHealthSystem playerHealthSystem;
    [SerializeField] float attackDamage;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            playerHealthSystem.TakeDamage(attackDamage);
        }
    }
}
