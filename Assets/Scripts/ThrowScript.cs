using System.Collections.Generic;
using UnityEngine;

public class ThrowScript : MonoBehaviour
{
    public float boxThrust = 10f;
    public GameObject boxPrefab;

    private Rigidbody mRigidBody;
    private Vector3 boxPosition;
    private Quaternion boxRotation;
    private bool canThrowing;
    private List<string> tags;

    private void Awake()
    {
        mRigidBody = GetComponent<Rigidbody>();
        mRigidBody.useGravity = false;
        canThrowing = true;
        tags = new List<string> { "Wall", "Box", "Floor" };
    }

    void Start()
    {
        boxPosition = transform.position;
        boxRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canThrowing)
        {
            mRigidBody.AddForce(transform.forward * boxThrust);
            mRigidBody.useGravity = true;
            canThrowing = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (tags.Contains(collision.gameObject.tag) && !canThrowing)
        {
            canThrowing = true;
            Instantiate(boxPrefab, boxPosition, boxRotation);
            Destroy(this);
        }
    }
}
