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
    bool lanternPresent = false;
    public GameObject lantern;
    public GameObject lightProjectile;
    public float projectileSpeed=10.0f;
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

    public void launchProjectile()
    {
        if (lanternPresent == true && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(lightProjectile, transform.position, transform.rotation);  //To launch Projectiles Smoothly
        }
    }
    //// Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Lantern")
        {

            
            if (Input.GetKeyDown(KeyCode.E))
            {
                lantern = other.gameObject;
                lantern.SetActive(false);
                lanternPresent = true;
            }
        }
    }

// =========================================PARENT CHILD IMPLEMENTATION OF LANTERN TO PLAYER ==============================//
        //public void launchProjectile() {
        //    if (lanternChildPresent == true && Input.GetKeyDown(KeyCode.Space)){
        //        Instantiate(lightProjectile,transform.position,transform.rotation);  //To launch Projectiles Smoothly
        //    }
        //}
        //// Update is called once per frame
        //private void OnTriggerStay(Collider other)
        //{
        //    if (other.gameObject.name == "Lantern")
        //    {   

        //        lantern = other.gameObject;
        //        if (Input.GetKeyDown(KeyCode.E))
        //        {
        //            lantern.transform.SetParent(transform);
        //            lantern.transform.position = transform.position;
        //            lantern.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);// not necessary but still keeping it
        //            DeactivateChild();
        //        }

        //    }
        //}
        //void DeactivateChild()
        //{
        //    lantern.SetActive(false);
        //    lantern.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // NTS -> objects can be manipulated even after setting it to false
        //    lanternChildPresent = true;
        //}  
        //Deactivates lantern after picking up but remains a child to the player
//============================================================================================================//
        void Update()
    {
        playerMovement();
        launchProjectile();
        
}
}
