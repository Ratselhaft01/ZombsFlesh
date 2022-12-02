using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] float range = 60f;
    [SerializeField] float damage = 1f;
    [SerializeField] float timeRemaining = 1;

    private Camera mainCamera;

    void Start() {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
        }
        else {
            if (Input.GetMouseButton(0)) {
                timeRemaining = 1f;
                DealDamage();
            }
        }
    }

    private void DealDamage() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            life_counter zombHealth = hit.transform.GetComponent<life_counter>();
            if (zombHealth == null) return;
            zombHealth.DealDamage(damage);
        }
        else {
            return;
        }
    }
}
