using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTouch : MonoBehaviour
{
    Camera cameraScreen;
    GameObject buildScreen;
    GameObject statsScreen;

    public float moveSpeed = 0.1f;
    public float ZoomSpeed = 0.1f;
    public bool screenProtector;
    GameEngine Engine;
    Ray ray;
    float screenBlocker;

    void Awake()
    {
        Engine = GameObject.Find("GameEngine").GetComponent<GameEngine>();
        if (Screen.width > 2000)
            screenBlocker = 500;
        else
            screenBlocker = 380;
    }


    private void Start()
    {
        cameraScreen = GameObject.Find("Main Camera").GetComponent<Camera>();
        buildScreen = GameObject.Find("Build");
        statsScreen = GameObject.Find("Stats");
    }



    void FixedUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (screenProtector)
            {
                if (Input.mousePosition.x < Screen.width - screenBlocker)
                    PhysicsRay(Input.mousePosition);
            }
            else
                PhysicsRay(Input.mousePosition);

            
        }


        if (Input.touchCount > 0)
        {
            Touch touchZero = Input.GetTouch(0);

            if (Input.touchCount == 1)
                if (touchZero.phase == TouchPhase.Moved)
                {
                    Vector2 touchDelta = touchZero.deltaPosition;
                    cameraScreen.transform.Translate(-touchDelta.x * moveSpeed, -touchDelta.y * moveSpeed, 0);

                    cameraScreen.transform.position = new Vector3(
                        Mathf.Clamp(cameraScreen.transform.position.x, Engine.minX, Engine.maxX),
                        cameraScreen.transform.position.y,
                        Mathf.Clamp(cameraScreen.transform.position.z, Engine.minZ, Engine.maxZ));
                }
                else
                {
                    if (screenProtector)
                    {

                        if (touchZero.position.x < Screen.width - screenBlocker)
                            PhysicsRay(touchZero.position);
                    }
                    else
                        PhysicsRay(touchZero.position);
                
                }

            
            if (Input.touchCount == 2)
            {
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float touchPrevMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
                float DeltaMag = touchPrevMag - touchDeltaMag;


                cameraScreen.transform.Translate(0,0, -DeltaMag * ZoomSpeed);
                cameraScreen.transform.position = new Vector3(cameraScreen.transform.position.x,
                                                              Mathf.Clamp(cameraScreen.transform.position.y, Engine.mixY, Engine.maxY),
                                                              cameraScreen.transform.position.z);
            }
        }
    }




    void PhysicsRay(Vector3 pos)
    {

        Ray ray = cameraScreen.ScreenPointToRay(pos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject objectHit = hit.transform.gameObject;
            if (objectHit.tag == "Platform")
            {
                statsScreen.SendMessage("Hide");
                buildScreen.SendMessage("Unhide", objectHit);
            }
            else
            if(objectHit.tag == "AutoTurret" || objectHit.tag == "Machinegun" || objectHit.tag == "Sniper" || objectHit.tag == "Louncher" || objectHit.tag == "Flamer" || objectHit.tag == "IceTurret")
            {
                buildScreen.SendMessage("Hide");
                statsScreen.SendMessage("Unhide", objectHit);
            }
            else
            {
                buildScreen.SendMessage("Hide");
                statsScreen.SendMessage("Hide");
            }
            
        }
        else
        {
            buildScreen.SendMessage("Hide");
            statsScreen.SendMessage("Hide");
        }
    }
}
