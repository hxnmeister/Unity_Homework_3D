using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 10;

    [SerializeField]
    private int health;

    private bool isDead = false;

    private bool isHitted = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitReaction()
    {
        if (!isDead)
        {
            if (--health <= 0)
            {
                isDead = true;
                isHitted = true;

                StartCoroutine(Death());
                if(TryGetComponent<WanderingAI>(out WanderingAI component)) component.Kill();

                Debug.Log("Target is dead!");
            }
            else
            {
                Debug.Log("Target is shot!");
            }
        }
    }

    public IEnumerator Death()
    {
        transform.Rotate(90, 90, 0);
        transform.Translate(0, 0, 1.5F);

        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}
