using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MouseLookHorizontal : MonoBehaviour
{
    [SerializeField]
    private float sensetive = 1000.0F;

    [SerializeField]
    private float maxVerticalAngle = 45.0F;

    [SerializeField]
    private float minVerticalAngle = -45.0F;

    private float xRotation = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float yRotation;

        xRotation -= Input.GetAxis("Mouse Y") * sensetive * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, minVerticalAngle, maxVerticalAngle);

        yRotation = transform.localEulerAngles.y;

        transform.localEulerAngles = new Vector3(xRotation, yRotation, 0);
    }
}
