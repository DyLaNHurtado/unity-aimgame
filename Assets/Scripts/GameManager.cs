using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	
[SerializeField] private GameObject focalPoint;
	private Vector3 screenPosition;
	private Vector3 worldPosition;
	private float limitTargetHorizontal = 22.0f;
	private float limitTargetTop = 26.5f;
	private float limitTargetBot = 2.5f;
	public Text counterText;
	private int count = 0;
	private int streak = 0;
	private int index = 0;
	[SerializeField] private List<GameObject> targetPrefabs;
	
	
    void Start()
    {
    	count = 0;
    }


    void Update()
    {
    	moveFocalPosition();
    	
    }
    
    private void moveFocalPosition(){
    	screenPosition = Input.mousePosition;
    	screenPosition.z = Camera.main.nearClipPlane + 3;
    	worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        focalPoint.transform.position = worldPosition;
        Debug.Log(focalPoint.transform.position);
    }
    
    private Vector3 GetTargetPos(){
    	return new Vector3(0,Random.Range(limitTargetBot,limitTargetTop),Random.Range(-limitTargetHorizontal,limitTargetHorizontal));
    }
    public void SpawnTarget(){
    	Instantiate(targetPrefabs[index],GetTargetPos(),targetPrefabs[index].transform.rotation);
    }
    public void updateCount(int countValue){
    	 count += countValue;
        counterText.text = "Count : " + count;
    }
    
    public void addStreakTarget(){
    	streak++;
    	updateIndex();
    }
    public void resetStreakTarget(){
    	streak = 0;
    	updateIndex();
    }
    
    private void updateIndex(){
    	if(streak <=2){
    	index = 0;
    	}else if(streak >2 && streak <=5){
    	index = 1;
    	}else{
    	index = 2;
    	}
    }
    
}
