using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
	
[SerializeField] private GameObject focalPoint;
	private Vector3 screenPosition;
	private Vector3 worldPosition;
	private const float  limitTargetHorizontal = 22.0f;
	private const float limitTargetTop = 26.5f;
	private const float limitTargetBot = 2.5f;
	public TMP_Text counterText;
	public TMP_Text streakText;
	private int count;
	private int streak;
	private int index;
	public bool isGameOver;
	[SerializeField] private List<GameObject> targetPrefabs;
	
	
    void Start()
    {
    	count = 0;
		streak = 0;
		index = 0;
		isGameOver = false;
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
    }
    
    private Vector3 GetTargetPos(){
    	return new Vector3(1,Random.Range(limitTargetBot,limitTargetTop),Random.Range(-limitTargetHorizontal,limitTargetHorizontal));
    }
    public void SpawnTarget(){
    	Instantiate(targetPrefabs[index],GetTargetPos(),targetPrefabs[index].transform.rotation);
    }
    public void updateCount(int countValue){
    	 count += countValue;
        counterText.text = "" + count;
    }
    
    public void addStreakTarget(){
    	streak++;
		Debug.Log(streak);
    	updateIndex();
		streakText.text = "x"+streak;
		Debug.Log(streakText.text);

    }
    public void resetStreakTarget(){
    	streak = 0;
    	updateIndex();
		streakText.text = "";
    }
    
    private void updateIndex(){
    	if(streak <=4){
    	index = 0;
    	}else if(streak >4 && streak <=10){
    	index = 1;
    	}else{
    	index = 2;
    	}
		
    }
    
}
