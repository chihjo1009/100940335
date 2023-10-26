using UnityEngine;
using TMPro;

public class AmmoManager : MonoBehaviour
{
    public int ammoCount = 10;
    public TextMeshProUGUI ammoText;

    private void Start()
    {
        UpdateAmmoUI();
    }

    private void UpdateAmmoUI()
    {
        ammoText.text = "Ammo: " + ammoCount.ToString();
    }

    // 這裡是獨立的AddAmmo方法，不在任何其他方法內部。
    public void AddAmmo(int amount)
    {
        ammoCount += amount;
        UpdateAmmoUI();
    }

    public bool TryShoot()
    {
        if (ammoCount > 0)
        {
            ammoCount--;
            UpdateAmmoUI();
            return true;
        }
        return false;
    }
}
