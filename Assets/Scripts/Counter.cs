using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private GameManager gameManagerScript;
    [SerializeField] private int countValue;

    private void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManagerScript.SpawnTarget();
        gameManagerScript.updateCount(countValue);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
