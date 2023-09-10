using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _Enemy;
    [SerializeField] private GameObject _Enemy_Container;

    private bool stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // spawn game objects every 5 seconds
    //Create a coroutine of type IEnumerator -- Yield Events
    // while loop infinite

    IEnumerator SpawnRoutine()
    {
        while(!stopSpawning)
        {
            float randomX = Random.Range(-11.5f, 11);        
            GameObject newEnemy = Instantiate(_Enemy, new Vector3(randomX, 9.0f, 0), Quaternion.identity);
            newEnemy.transform.parent = _Enemy_Container.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }


    public void OnPlayerDeath()
    {
        stopSpawning = true;
    }

}
