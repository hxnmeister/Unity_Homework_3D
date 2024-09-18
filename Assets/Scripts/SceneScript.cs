using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject targetPrefab;

    private readonly GameObject[] targets = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (!targets[i])
            {
                targets[i] = Instantiate(targetPrefab);
                targets[i].transform.position = new Vector3(Random.Range(-25F, 25F), 0.5F, Random.Range(-25F, 25F));
                targets[i].transform.Rotate(0, Random.Range(0, 360F), 0);
            }
        }
    }
}
