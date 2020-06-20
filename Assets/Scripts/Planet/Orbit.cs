using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] Transform _origin;
    [SerializeField] float _speed = 45f;

    public void rotateRigidBodyAroundPointBy(Rigidbody rb, Vector3 origin, Vector3 axis, float angle)
    {
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        rb.MovePosition(q * (rb.transform.position - origin) + origin);
        rb.MoveRotation(rb.transform.rotation * q);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_origin)
        {
            rotateRigidBodyAroundPointBy(GetComponent<Rigidbody>(), _origin.position, Vector3.up, _speed * Time.fixedDeltaTime);
        }
    }
}
