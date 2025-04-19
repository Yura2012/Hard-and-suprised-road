using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGrab : MonoBehaviour
{
    public float maxDistance = 10f; // Максимальна відстань з якої можна брати предмети
    public float force = 10f; // Сила притягування предметів

    private bool holdingObject = false;
    private Rigidbody grabbedObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Змініть це на будь-яку кнопку, яку ви хочете використовувати для захоплення об’єктів
        {
            if (!holdingObject)
            {
                GrabObject();
            }
            else
            {
                ReleaseObject();
            }
        }

        if (holdingObject)
        {
            UpdateObjectPosition();
        }
    }

    void GrabObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                grabbedObject = rb;
                grabbedObject.isKinematic = true; // Disable physics simulation while holding the object
                holdingObject = true;
            }
        }
    }

    void ReleaseObject()
    {
        if (grabbedObject != null)
        {
            grabbedObject.isKinematic = false; // Enable physics simulation
            grabbedObject = null;
            holdingObject = false;
        }
    }

    void UpdateObjectPosition()
    {
        // Move the grabbed object to the gun's position
        grabbedObject.MovePosition(transform.position + transform.forward * 2f);

        // Apply force to the object to simulate attraction
        Vector3 forceDirection = (transform.position - grabbedObject.position).normalized;
        grabbedObject.AddForce(forceDirection * force);
    }
}
