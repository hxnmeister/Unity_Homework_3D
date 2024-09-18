using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class RayShooter : MonoBehaviour
{
    [SerializeField]
    private GUIStyle _style;

    [SerializeField]
    private float normalFOV = 60.0F;

    [SerializeField]
    private float scopedFOV = 40.0f;

    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 cameraCenter = new(_camera.pixelWidth / 2.0F, _camera.pixelHeight / 2.0F, 0);
            Ray ray = _camera.ScreenPointToRay(cameraCenter);

            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                GameObject hittedObject = hitInfo.collider.gameObject;
                ReactiveTarget target = hittedObject.GetComponent<ReactiveTarget>();

                if(target)
                {
                    target.HitReaction();
                    Debug.Log($"Hit at: {hitInfo.point}");

                }
                else
                {
                    StartCoroutine(CreateHitSphere(hitInfo.point));
                }
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            _camera.fieldOfView = scopedFOV;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            _camera.fieldOfView = normalFOV;
        }
    }

    private void OnGUI()
    {
        const char crosshair = '+';
        float size = _style.fontSize;
        float x = _camera.pixelWidth / 2.0F - size / 2.0F;
        float y = _camera.pixelHeight / 2.0F - size / 2.0F;

        GUI.Label(new Rect(x, y, size, size), crosshair.ToString(), _style);
    }

    private IEnumerator CreateHitSphere(Vector3 hitPoint)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sphere.transform.position = hitPoint;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
