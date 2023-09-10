using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // public or private refrence to variable
    // data type (int, float, bool, string)
    [SerializeField]
    private float _speed = 11.0f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.85f;
    private float _nextFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (spawnManager == null)
        {
            Debug.LogError("Spawn manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculatePos();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            FireLaser();
        }
    }

    void CalculatePos()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        if (transform.position.y < -5.38f)
        {
            transform.position = (new Vector3(transform.position.x, 7.5f, 0));
        }
        else if (transform.position.y > 7.6f)
        {
            transform.position = (new Vector3(transform.position.x, -5.38f, 0));
        }

        if (transform.position.x > 11.5f || transform.position.x < -11.5f)
        {
            transform.position = new Vector3(-1 * transform.position.x, transform.position.y, 0);
        }
    }


    void FireLaser()
    {
        
        _nextFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        

    }

    public void Damage()
    {
        _lives -= 1;
        if (_lives < 1)
        {
            spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }


}
