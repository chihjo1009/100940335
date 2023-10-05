using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private int value = 0;

    private void Start()
    {
        Debug.Log("Score: " + value); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("diamond"))
        {
            AddDiamond();
            Destroy(other.gameObject);
        }
    }

    private void AddCoin()
    {
        value++;
        Debug.Log("Score:  " + value);
    }

    private void AddDiamond()
    {
        value = value + 5;
        Debug.Log("Score: " + value);
    }
}
