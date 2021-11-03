using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.UI;

/** Script for Sliding along a Rail
 *  Author: Adrian Hartmann
 *  
 *  This Script takes care of the behaviour during sliding. It temporarily disables the default PlayerController as well as its physics.
 *  
 * 
 */

public class CurveRider : MonoBehaviour
{
    //PUBLIC Values
    public float speed = 5;
    public float deadzone = 2;

    [Range(0, 2)]
    public float sensitivity = 1;

    public EndOfPathInstruction end = EndOfPathInstruction.Stop;
    public GameObject balanceBar;
    public GameObject balanceIndicator;

    public AudioClip grind_sound;
    AudioSource soundEffects;
    AudioClip default_audio;
    
    private Animator blobAnimator;




    //PRIVATE Variables
    Rigidbody body;
    float smoothing = 20;
    PathCreator path;
    float distance;
    bool en = false;
    //local z-angle
    float z_angle;
    //global y_angle
    float y_angle;

    // Start is called before the first frame update
    void Start()
    {
        //Hide UI Components
        balanceBar.GetComponent<Image>().enabled = false;
        balanceIndicator.GetComponent<Image>().enabled = false;

        //Get Rigidbody component
        body = GetComponent<Rigidbody>();
        
        //Get Animator
        blobAnimator = GetComponentInChildren<Animator>();

        //get AudioSource
        soundEffects = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider thing)
    {
        if (thing.gameObject.CompareTag("Rail") && !en)
        {
            //disable Physics while sliding
            this.GetComponent<PlayerController>().enabled = false;
            body.useGravity = false;
            body.isKinematic = true;

            //enable curve following
            path = thing.GetComponent<PathCreator>();
            en = true;
            distance = 0;
            z_angle = 0;
            y_angle = body.rotation.y;

            //Enable UI
            balanceBar.GetComponent<Image>().enabled = true;
            balanceIndicator.GetComponent<Image>().enabled = true;
            
            //Start animation
            blobAnimator.SetBool("IsGrinding", true);

            //sound
            default_audio = soundEffects.clip;
            soundEffects.clip = grind_sound;
            soundEffects.Play();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (en)
        {
            //kepp track of travelled distance
            distance += speed * Time.deltaTime;

            //Move Body Position
            body.position += Time.deltaTime * smoothing * (path.path.GetPointAtDistance(distance, end) - body.position);


            if (distance < deadzone)//deadzone of 2m at start
            {
                //Smoooth Angle Transition
                body.rotation = Quaternion.RotateTowards(body.rotation, path.path.GetRotationAtDistance(distance, end), 200 * Time.deltaTime);
            }
            else
            {
                float in_h = sensitivity * Input.GetAxis("Horizontal");

                //remember change in y-rotation
                float y_change = body.rotation.y - y_angle;

                //filter random peaks
                if (y_change < 0 && y_change < -0.5f * Time.deltaTime)
                {
                    y_change = -0.5f * Time.deltaTime;
                }
                else if (y_change > 0 && y_change > 0.5f * Time.deltaTime)
                {
                    y_change = 0.5f * Time.deltaTime;
                }

                //change z-Rotation (rail balancing) depending on turn speed  
                z_angle += 45 * y_change - in_h + z_angle * Time.deltaTime;
                y_angle = body.rotation.y;

                //Assign Rotation
                body.MoveRotation(Quaternion.RotateTowards(body.rotation, Quaternion.AngleAxis(z_angle, path.path.GetDirectionAtDistance(distance, end)) * path.path.GetRotationAtDistance(distance, end), 200 * Time.deltaTime));

                //Update UI accordingly
                balanceIndicator.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, z_angle);

            }



            //Stop Curve Following at the end or with |z_angle| > 35 degrees
            if (path.path.length <= distance || z_angle > 35 || z_angle < -35)
            {
                en = false;

                //assign exit velocity 
                body.velocity = path.path.GetDirectionAtDistance(distance, end) * speed + 3 * Vector3.up;

                //Restore Physics
                body.useGravity = true;
                this.GetComponent<PlayerController>().enabled = true;
                body.isKinematic = false;

                balanceBar.GetComponent<Image>().enabled = false;
                balanceIndicator.GetComponent<Image>().enabled = false;

                //stop strange exit movement
                body.angularVelocity = Vector3.zero;

                //reset UI
                balanceIndicator.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);

                //End animation
                blobAnimator.SetBool("IsGrinding", false);

                //sound
                soundEffects.clip = default_audio;
            }

        }
    }

}
