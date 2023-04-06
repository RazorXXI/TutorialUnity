using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    float moveHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }


    private void Update()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        ReadInput();
        DisplaceObject();
    }

    void ReadInput()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
    }

    void DisplaceObject()
    {
        rb.velocity = new Vector2(moveHorizontal * speed * Time.fixedDeltaTime, rb.velocity.y);
