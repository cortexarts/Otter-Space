using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour
{
    public Vector3 Pivot;
    public bool DebugInfo = true;

    //it could be a Vector3 but its more user friendly
    public bool RotateX = false;
    public bool RotateY = true;
    public bool RotateZ = false;

    void FixedUpdate()
    {
        transform.position += (transform.rotation * Pivot);

        if (RotateX)
            transform.rotation *= Quaternion.AngleAxis(45 * Time.deltaTime, Vector3.right);
        if (RotateY)
            transform.rotation *= Quaternion.AngleAxis(45 * Time.deltaTime, Vector3.up);
        if (RotateZ)
            transform.rotation *= Quaternion.AngleAxis(45 * Time.deltaTime, Vector3.forward);

        transform.position -= (transform.rotation * Pivot);

        if (DebugInfo)
        {
            Debug.DrawRay(transform.position, transform.rotation * Vector3.up, Color.black);
            Debug.DrawRay(transform.position, transform.rotation * Vector3.right, Color.black);
            Debug.DrawRay(transform.position, transform.rotation * Vector3.forward, Color.black);

            Debug.DrawRay(transform.position + (transform.rotation * Pivot), transform.rotation * Vector3.up, Color.green);
            Debug.DrawRay(transform.position + (transform.rotation * Pivot), transform.rotation * Vector3.right, Color.red);
            Debug.DrawRay(transform.position + (transform.rotation * Pivot), transform.rotation * Vector3.forward, Color.blue);
        }
    }
}