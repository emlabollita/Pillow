using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuforiaCameraFocus : MonoBehaviour
{
    private bool statusTracking = true;
    public GameObject vuforiaCamera, cubeCamera;

    // Start is called before the first frame update
    void Start()
    {
        Main();

        bool focusModeSet = CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        if (!focusModeSet)
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_INFINITY);
            Debug.Log("No es soportado.");
        }
        else {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_MACRO);
            Debug.Log("Si es soportado.");
        }
    }

    private void Main() {
        cubeCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
        }
    }

    public void SetCameraTracking() {
        if (statusTracking) {
            statusTracking = false;
            TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
        }
        else {
            statusTracking = true;
            TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
        }
    }

    public void SwitchCamera(bool active) {

        if (active)
        {
            VuforiaBehaviour.Instance.enabled = true;
            Vuforia.CameraDevice.Instance.Start();
            vuforiaCamera.SetActive(true);
            cubeCamera.SetActive(false);
        }
        else {
            VuforiaBehaviour.Instance.enabled = false;
            Vuforia.CameraDevice.Instance.Stop();
            vuforiaCamera.SetActive(false);
            cubeCamera.SetActive(true);
        }

    }
}
