using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0F;

    [SerializeField]
    private int damage = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();

        if (player)
        {
            player.TakeDamage(damage);
        }

        Destroy(gameObject);
        Debug.Log("Player died!");
    }
}
