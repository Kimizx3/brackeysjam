using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Drag : MonoBehaviour
{
    [SerializeField] private float grabblingRange = 3;
    [SerializeField] private float pullingRange = 20;
    [SerializeField] private Transform holdPoint = null;
    [SerializeField] private KeyCode grabKey = KeyCode.E;
    [SerializeField] private float pullForce = 50;
    [SerializeField] private float grabBreakingForce = 100f;
    [SerializeField] private float grabBreakingTorque = 100f;

    [SerializeField] private TextMeshPro UseText;

    private FixedJoint grabJoint;
    private Rigidbody grabbedRigidbody;

    private void Awake()
    {
        if (holdPoint == null)
        {
            Debug.LogError("Grab hold point must not be null!");
        }

        if (holdPoint.IsChildOf(transform) == false)
        {
            Debug.LogError("Grab hold point must be a child of this object");
        }

        var playerCollider = GetComponentInParent<Collider>();

        playerCollider.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void Update()
    {
        if (Input.GetKey(grabKey) && grabJoint == null)
        {
            AttemptPull();
        }
        else if (Input.GetKeyDown(grabKey) && grabJoint != null)
        {
            Drop();
        }
    }

    private void AttemptPull()
    {
        var ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        var everythingExceptPlayer = ~(1 << LayerMask.NameToLayer("Player"));
        var layerMask = Physics.DefaultRaycastLayers & everythingExceptPlayer;
        var hitSomething = Physics.Raycast(ray, out hit, pullingRange, layerMask);
        
        if (hitSomething == false)
        {
            return;
        }

        grabbedRigidbody = hit.rigidbody;

        if (grabbedRigidbody == null || grabbedRigidbody.isKinematic)
        {
            return;
        }

        if (hit.distance < grabblingRange)
        {
            grabbedRigidbody.transform.position = holdPoint.position;

            grabJoint = gameObject.AddComponent<FixedJoint>();
            grabJoint.connectedBody = grabbedRigidbody;
            grabJoint.breakForce = grabBreakingForce;
            grabJoint.breakTorque = grabBreakingTorque;

            foreach (var myCollider in GetComponentsInParent<Collider>())
            {
                Physics.IgnoreCollision(myCollider,hit.collider,true);
            }
        }
        else
        {
            var pull = -transform.forward * this.pullForce;
            grabbedRigidbody.AddForce(pull);
        }
    }

    private void Drop()
    {
        if (grabJoint != null)
        {
            Destroy(grabJoint);
        }

        if (grabbedRigidbody == null)
        {
            return;
        }

        foreach (var myCollider in GetComponentsInParent<Collider>())
        {
            Physics.IgnoreCollision(myCollider, grabbedRigidbody.GetComponent<Collider>(), false);
        }

        grabbedRigidbody = null;
    }

    private void OnDrawGizmos()
    {
        if (holdPoint == null)
        {
            return;
        }
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(holdPoint.position, 0.2f);
    }

    private void OnJointBreak(float breakForce)
    {
        Drop();
    }
}
