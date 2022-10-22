using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    private Rigidbody bulletRb;
    private GameObject focalPoint;
    private GameManager gameManagerScript;
    void Start()
    {
    	focalPoint = GameObject.Find("FocalPoint");
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.AddForce(GetPositionForce(),ForceMode.Impulse);
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    
    void OnTriggerEnter(Collider collision){
    	if(collision.gameObject.tag=="Target"){
    		gameManagerScript.addStreakTarget();
    	}else{
    		gameManagerScript.resetStreakTarget();
    	}
        Destroy(gameObject);
    }
    
    private Vector3 GetPositionForce(){
    	return (focalPoint.transform.position-transform.position) * speed;
    }
    
}
