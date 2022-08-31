using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    [SerializeField] int currentWeapon = 0;
    void Start()
    {
        SetActiveWeapon();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != currentWeapon) {
            gameObject.transform.GetChild(previousWeapon).gameObject.SetActive(false);
            SetActiveWeapon();
        }
    }

    private void ProcessKeyInput() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            currentWeapon = 0;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            currentWeapon = 1;
        }
    }

    private void ProcessScrollWheel() {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            if (currentWeapon >= transform.childCount - 1) {
                currentWeapon = 0;
            } else {
                currentWeapon++;
            }
        } else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            if (currentWeapon == 0) {
                currentWeapon = transform.childCount - 1;
            } else {
                currentWeapon--;
            }
        }
    }


    private void SetActiveWeapon() {
        gameObject.transform.GetChild(currentWeapon).gameObject.SetActive(true);
    }
}
