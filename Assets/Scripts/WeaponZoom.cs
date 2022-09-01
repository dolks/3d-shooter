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

    [SerializeField] RigidbodyFirstPersonController firstPersonController;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z)) {
            ZoomIn();
        } else {
            ZoomOut();
        }
    }

    private void OnDisable() {
        ZoomOut();
    }

    private void ZoomIn() {
        mainCamera.fieldOfView = zoomedInView;
        firstPersonController.mouseLook.XSensitivity = zoomedInSensitivity;
        firstPersonController.mouseLook.YSensitivity = zoomedInSensitivity;
    }

    private void ZoomOut() {
        mainCamera.fieldOfView = zoomedOutView;
        firstPersonController.mouseLook.XSensitivity = zoomedOutSensitivity;
        firstPersonController.mouseLook.YSensitivity = zoomedOutSensitivity;
    }


}
