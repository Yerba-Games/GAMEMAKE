using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class plater : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputX;
    private float inputY;
    public float speed = 9999f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        inputX = movementVector.x;
        inputY = movementVector.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(inputX * speed * Time.deltaTime, 0,0);
    }
}