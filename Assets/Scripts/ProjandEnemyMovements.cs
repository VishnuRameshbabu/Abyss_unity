using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjandEnemyMovements : MonoBehaviour
{
    public float speed = 3.75f;
    float topbound = 30f;
    float lowerbound = -12f;
    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //    if (transform.position.z > topbound)//projectile
        //    {
        //        Destroy(gameObject);
        //    }
        //    else if (transform.position.z < lowerbound)//animal
        //    {
        //        Destroy(gameObject);
        //        Debug.Log("Game Over :( ");
        //    }
        
    }
}
