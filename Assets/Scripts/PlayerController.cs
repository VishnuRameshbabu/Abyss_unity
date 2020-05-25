using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    //public Rigidbody playerRb;
    public float speed = 1f;
    public float turnSpeed = 50f;
    
    // Start is called before the first frame update
    void Start()
    {
        //playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        float turnHorizontal, turnVertical;
        turnHorizontal = turnSpeed * Input.GetAxis("Mouse X");
        turnVertical = turnSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, turnVertical, 0);
        //playerRb.AddForce(transform.forward * verticalInput * Time.deltaTime * speed );
        if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.W)))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            
        }
        if ((Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.S)))
        {
            transform.Translate(Vector3.back * Time.deltaTime * (-speed) * verticalInput);

        }
        if ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.A)))
        {
            transform.Translate(Vector3.left * Time.deltaTime * (-speed) * horizontalInput);

        }
        if ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D)))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        }
        
    }
}
