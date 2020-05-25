using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    //public Rigidbody playerRb;
    public float speed = 1f;
    public float turnSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        //playerRb = GetComponent<Rigidbody>();
    }

    void playerMovement() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        float turnHorizontal;
        turnHorizontal = turnSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, turnHorizontal * turnSpeed * Time.deltaTime); ;
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

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Lantern")
        {
            GameObject lantern = other.gameObject;
            if (Input.GetKeyDown(KeyCode.E))
            {
                lantern.transform.SetParent(transform);
                lantern.transform.position = transform.position;
                lantern.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            }
        }
        
    }
    void DeactivateChild()
    {
      
         transform.Find("Lantern_picked").gameObject.SetActive(false);    }  //Deactivates lantern after picking up but remains a child to the player
                                                                                                    
    void Update()
    {
        playerMovement();
        DeactivateChild();
}
}
