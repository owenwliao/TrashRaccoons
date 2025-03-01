using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRaccoonRotation : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float bobbingSpeed = 1f;
    public float bobbingHeight = 10f;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the game object around its Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Bob the game object up and down
        float newY = startPosition.y + Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
