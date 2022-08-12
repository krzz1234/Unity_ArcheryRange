using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    // Data Members
    public GameObject ArrowPrefab;
    public float Strength;
    
    // Rigidbody Component
    private Rigidbody rb;

    // Mouse Sensitivity
    public float Sensitivity = 1.0f;

    // Player Speed
    public float Speed = 5.0f;

    // Start - called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update - called once per frame
    void Update() {
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Sensitivity, Space.World);
        transform.Rotate(Vector3.right, -Input.GetAxis("Mouse Y") * Sensitivity, Space.Self);

        if(Input.GetMouseButtonDown(0)) {
        GameObject arrow = Instantiate(
        ArrowPrefab,
        transform.position +
        transform.right * 0.07325f +
        transform.up * 0.1355f +
        transform.forward * 0.163f,
        transform.rotation);
        arrow.GetComponent<Rigidbody>().AddRelativeForce(
        Vector3.forward * Strength,
        ForceMode.VelocityChange);
        }
    }

    // FixedUpdate - called oncer per physics frame
    void FixedUpdate() {
        // Project the forward vector onto the horiztonal plane
        Vector3 forward = Vector3.Normalize(rb.transform.forward - Vector3.up * Vector3.Dot(rb.transform.forward, Vector3.up));

        // Right Vector
        Vector3 right = rb.transform.right;

        // Calculate new Position
        Vector3 newPosition = rb.transform.position +
                              Input.GetAxis("Vertical") * Time.fixedDeltaTime * Speed * forward + 
                              Input.GetAxis("Horizontal") * Time.fixedDeltaTime * Speed * right;

        // Move to new Position
        rb.MovePosition(newPosition);
    }
}
