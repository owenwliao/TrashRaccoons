using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour
{
    public Transform startPoint; // Starting point
    public Transform midPoint; // Mid point
    public Transform endPoint; // End point
    public float speed = 5f; // Speed of the car
    public float pushForceMultiplier = 10f; // Multiplier for the force to apply to the player

    private int currentTargetIndex = 0;
    private Transform[] points;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        if (startPoint == null || midPoint == null || endPoint == null)
        {
            Debug.LogError("Start Point, Mid Point, or End Point is not set for CarMovement.");
        }
        else
        {
            points = new Transform[] { startPoint, midPoint, endPoint };
            transform.position = startPoint.position; // Start at start point
        }

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing from the car.");
        }
        else
        {
            rb.isKinematic = true; // Make the Rigidbody kinematic
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startPoint == null || midPoint == null || endPoint == null) return;

        MoveCar();
    }

    void MoveCar()
    {
        Transform targetPoint = points[currentTargetIndex];
        Vector3 direction = targetPoint.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            // Reached the target point
            currentTargetIndex++;
            if (currentTargetIndex >= points.Length)
            {
                // Teleport back to start point
                transform.position = startPoint.position;
                currentTargetIndex = 1; // Move towards mid point next
            }
        }
        else
        {
            // Move towards the target point
            transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detected with: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger with player detected.");
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 pushDirection = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
                float pushForce = speed * pushForceMultiplier;
                Debug.Log($"Applying force: {pushForce} in direction: {pushDirection}");
                playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);

                // Restart the game
                Debug.Log("Restarting the game...");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Debug.LogError("Player Rigidbody is missing.");
            }
        }
    }
}
