using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 4.0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        
        

    }


    void EnemyMovement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if (transform.position.y < -8.0f)
        {
            float randomX = Random.Range(-11.5f, 11);
            transform.position = new Vector3(randomX, 9.0f, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if other is player
        // damage the player
        // Destroy Us
        if(other.tag == "Player")
        {
            // damage player
            other.transform.GetComponent<player>().Damage();
            Destroy(this.gameObject);
        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        // if other is laser 
        // laser
        // destroy us


    }

}
