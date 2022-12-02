using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hordes : MonoBehaviour
{
    [SerializeField] GameObject zombie;
    [SerializeField] float timeRemaining = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0) {
        timeRemaining -= Time.deltaTime;
        }
        else {
            timeRemaining = 10f;
            for (var i = 5; i > 0; i--) {
                GameObject instZombie = Instantiate(zombie, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
                instZombie.transform.parent = transform;
            }
        }
        
    }

    Vector3 RandomSpawn() {
        return new Vector3(0, 0, 0);
    }
}
