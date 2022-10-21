using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Vector3 offset;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
        	Instantiate(bulletPrefab, offset,bulletPrefab.transform.rotation);
        }
    }
}
