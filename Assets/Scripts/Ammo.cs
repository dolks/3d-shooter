using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    [System.Serializable]
    private class AmmoSlot {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int getCurrentAmmo(AmmoType ammoType) {return GetAmmoSlot(ammoType).ammoAmount;}

    public void reduceCurrentAmmo(AmmoType ammoType) {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void increaseCurrentAmmo(AmmoType ammoType, int amount) {
        GetAmmoSlot(ammoType).ammoAmount+=amount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType) {
        foreach(AmmoSlot slot in ammoSlots) {
            if (slot.ammoType == ammoType) {
                return slot;
            }
        }
        return null;
    }
}
