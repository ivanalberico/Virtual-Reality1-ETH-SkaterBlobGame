using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Camera Following Script
 * Author: Adrian Hartmann
 * 
 * The principle is to simply rotate the initial distance between Player
 * and Camera only around the Y-(Up)-Axis and smooth the translation. 
 * 
 */
public class CameraFollower : MonoBehaviour
{
    public GameObject player;
    

    Vector3 initial_offset;
    public float smoothness = 5f;
    float camera_Angle;
    float initial_Angle;
    
 
    
    // Start is called before the first frame update
    void Start()
    {
        initial_offset = transform.position - player.transform.position;
        initial_Angle = player.transform.rotation.eulerAngles.y;
        camera_Angle = transform.rotation.eulerAngles.y;

    }

    // Update is called once per frame
    void Update()
    {

        //Smooth camera Rotation 
        float corr = 0;
        if (player.transform.rotation.eulerAngles.y - camera_Angle > 180) corr = -360; //Do weird stuff to prevent Angle-rollover
        else if (player.transform.rotation.eulerAngles.y - camera_Angle < -180) corr = +360;
        camera_Angle = camera_Angle + smoothness*Time.deltaTime*(player.transform.rotation.eulerAngles.y - camera_Angle+corr) %360;
        if (camera_Angle > 180) camera_Angle -= 360;
        else if (camera_Angle < -180) camera_Angle += 360;

        //Calculate Camera Position
        Vector3 offset = Quaternion.Euler(0, camera_Angle-initial_Angle, 0) * initial_offset;
        transform.position = player.transform.position + offset;

        //Apply Camera Rotation
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camera_Angle , transform.rotation.eulerAngles.z);

        
    }
}
