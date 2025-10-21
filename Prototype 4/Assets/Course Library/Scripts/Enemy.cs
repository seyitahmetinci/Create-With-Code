using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private GameObject player;
    private Rigidbody enemy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemy.AddForce(lookDirection * speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        
    }
}
