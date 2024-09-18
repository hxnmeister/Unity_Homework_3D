using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MouseLookVertical : MonoBehaviour
{
    [SerializeField]
    private float sensetive = 1000.0F;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensetive * Time.deltaTime, 0);
    }
}
