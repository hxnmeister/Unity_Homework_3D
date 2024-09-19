using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField]
    private GameObject FireballPrefab;

    [SerializeField]
    private float speed = 5.0F;

    [SerializeField]
    private float obsctacleRange = 15.0F;

    private bool alive = true;
    private GameObject fireball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive) return;

        Ray ray = new(transform.position, transform.forward);

        transform.Translate(0, 0, speed * Time.deltaTime);

        if (Physics.SphereCast(ray, 0.75F, out RaycastHit hit))
        {
            GameObject gameObject = hit.transform.gameObject;

            if (gameObject.GetComponent<PlayerCharacter>())
            {
                if(!fireball)
                {
                    fireball = Instantiate(FireballPrefab);
                    fireball.transform.SetPositionAndRotation(transform.TransformPoint(new Vector3(0, 1F, 1.5F)), transform.rotation);
                }
            }
            else if (hit.distance < obsctacleRange)
            {
                transform.Rotate(0, Random.Range(-110F, 110F), 0);
            }
        }
    }

    public void Kill()
    {
        alive = false;
    }
}
