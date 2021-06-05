using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastAR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //corresponde al touch de la pantalla
        if (Input.touchCount > 0) {

            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            RaycastHit hit;

            if (Physics.Raycast(raycast, out hit)) {

                if (hit.collider.gameObject.name == "BtnPlay")
                {
                    GameObject.Find("ImageTargetVideoPlayer").gameObject.GetComponent<VideoPlayerController>().StartVideo();
                }
            }
        }
    }
}
