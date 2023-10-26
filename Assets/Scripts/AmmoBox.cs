using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int ammoAmount = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AmmoManager ammoManager = other.GetComponent<AmmoManager>();
            if (ammoManager != null)
            {
                ammoManager.AddAmmo(ammoAmount);
                Destroy(gameObject);
            }
        }
    }
}
