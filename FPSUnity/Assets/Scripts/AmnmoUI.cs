
using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    public TMP_Text ammoText;

    public void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        ammoText.text = "AMMO: " + currentAmmo + " / " + maxAmmo;
    }
}
