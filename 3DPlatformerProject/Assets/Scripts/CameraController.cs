using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerTransform;
    public Transform pivot;
    [SerializeField]private Vector3 offset;
    [SerializeField] private float rotateSpeed = 1.0f;

   /*[Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;*/
    public bool myOffsetvalues;
    public float maxViewAngle;
    public float minViewAngle;
    public bool invertY;
    

    // Start is called before the first frame update
    void Start()
    {
        if (!myOffsetvalues)
        {
            offset = transform.position - playerTransform.position;
        }

        pivot.transform.position = playerTransform.transform.position;


        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        playerTransform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        if(invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        if(pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }

        if(pivot.rotation.eulerAngles.x > 180 && pivot.eulerAngles.x < 360f + minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
        }


        float desiredYAngle = playerTransform.eulerAngles.y;
        float desiredXangle = playerTransform.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXangle, desiredYAngle, 0);
        transform.position = playerTransform.position - (rotation * offset);

        if(transform.position.y < playerTransform.position.y)
        {
            transform.position = new Vector3(transform.position.x, playerTransform.position.y - 5f, transform.position.z);
        }
        transform.LookAt(playerTransform);
    }
}
