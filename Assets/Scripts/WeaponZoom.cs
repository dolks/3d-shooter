using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] float zoomedOutView = 60;
    [SerializeField] float zoomedInView = 20;
    [SerializeField] float zoomedOutSensitivity = 5;
    [SerializeField] float zoomedInSensitivity = 2;

    RigidbodyFirstPersonController firstPersonController;

    private void Start () {
        firstPersonController = GetComponent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Z)) {
            mainCamera.fieldOfView = zoomedInView;
            firstPersonController.mouseLook.XSensitivity = zoomedInSensitivity;
            firstPersonController.mouseLook.YSensitivity = zoomedInSensitivity;
        } else {
            mainCamera.fieldOfView = zoomedOutView;
            firstPersonController.mouseLook.XSensitivity = zoomedOutSensitivity;
            firstPersonController.mouseLook.YSensitivity = zoomedOutSensitivity;
        }
    }
}
