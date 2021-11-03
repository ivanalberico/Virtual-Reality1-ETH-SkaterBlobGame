using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Player Movement Script
 * Author: Adrian Hartmann
 * 
 * This script simulates the driving Physics of the Player. 
 * In a nutshell the skateboard has a suspension system of 4 spring-damper systems, made with Raycasts, 
 * and some simple physics for acceleration and rotation.
 * 
 */
public class PlayerController : MonoBehaviour
{

    public float max_speed = 10;
    public float acceleration = 10;
    public float rotation = 90;
    public float jump = 5;
    //Object for the Postion of the Center of Mass for the rigidbody
    public GameObject CoM;
    public float friction = 0.8f;
    public float springK = 0.5f;
    public float springD = 6;
    public float max_spring_extension = 0.15f;
    [Range(0,10)]
    public float stabilizationCoef = 1;

    public GameObject[] Wheels = new GameObject[4];

    //Audio Sources
    public AudioClip halt_sound;
    public AudioClip jump_sound;
    public AudioClip fall_sound;

    AudioSource soundEffects;
    float collisionSoundDelay;

    //Minumum turning radius of the skateboard
    float min_radius = 1;

    //some used variables
    float in_h = 0;
    float in_v = 0;
    Rigidbody body;
    bool isGrounded = false;
    public Vector3 vel = new Vector3(0f, 0f, 0f);

    //Initial Wheel Position
    Vector3[] pos_Wheels = new Vector3[4];

    //Force and postion variables for Wheel Suspension
    float[] f_wheels = new float[4];
    float[] y_wheels = new float[4];

    Vector3 ground_normal = new Vector3(0,1,0);


    // for Boost platform
    public bool boosting = false;


    private Animator blobAnimator;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.centerOfMass = transform.InverseTransformPoint(CoM.transform.position);
        //Set up Wheel Suspension Variables 
        for(int i = 0; i<4; i++)
        {
            pos_Wheels[i] = transform.InverseTransformPoint(Wheels[i].transform.position + new Vector3(0, 0.05f, 0));
            y_wheels[i] = 0.1f;

        }
        //Increase wheel distance slightly
        pos_Wheels[0] += new Vector3(-0.05f, 0, 0);
        pos_Wheels[1] += new Vector3(0.05f, 0, 0);
        pos_Wheels[2] += new Vector3(-0.05f, 0, 0);
        pos_Wheels[3] += new Vector3(0.05f, 0, 0);
        
        blobAnimator = GetComponentInChildren<Animator>();

        soundEffects = GetComponent<AudioSource>();
        soundEffects.volume = PlayerPrefs.GetFloat("volume")*2;
        collisionSoundDelay = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collisionSoundDelay > 1 && collision.impulse.magnitude > 3)
        {
            soundEffects.PlayOneShot(halt_sound);
            collisionSoundDelay = 0;

        }
    }


    private void Update()
    {
        
        //ButtonDown only works  in Update()
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            body.AddForce(jump * Vector3.up,ForceMode.Impulse);
            isGrounded = false;
            blobAnimator.SetTrigger("Jump Trigger");

            //Sound
            soundEffects.PlayOneShot(jump_sound,0.7f);
        }
        
        //Soundeffects
        if (!soundEffects.isPlaying && vel.magnitude > 1 && isGrounded)
        {
            soundEffects.Play();
        }
        else if (vel.magnitude < 1 || !isGrounded)
        {
            soundEffects.Pause();
        }
        collisionSoundDelay += Time.deltaTime;

        //Adjust animation to speed
        blobAnimator.SetFloat("Movement Speed", vel.magnitude/max_speed);
    }
    
    void FixedUpdate()
    {

        in_h = Input.GetAxis("Horizontal");
        in_v = Input.GetAxis("Vertical");

        isGrounded = false;

        check_suspension();

        //more tolerance for jumping:
        RaycastHit hit;
        if (Physics.Raycast(CoM.transform.position, -transform.up,out hit, 2 * max_spring_extension)) {
            isGrounded = true;
            //Debug.Log("Hit: "+hit.collider.gameObject.name);
        }

        //Control Velocity
        if (isGrounded)
        {
            groundMovement();
        }
        else
        {
            airMovement();
        }

        //stabilization
        if (Physics.Raycast(CoM.transform.position, -Vector3.up, out hit, 0.2f))
        {
            ground_normal = hit.normal;
        }
        else
        {
            //slowly move towards world Y-Axis during flight
            ground_normal += Time.deltaTime * 0.2f*(Vector3.up - ground_normal);
        }
        //Apply torque towards ground_normal
        Vector3 stabilization_vec = Vector3.Cross(transform.up, ground_normal);
        body.AddTorque(stabilization_vec * stabilizationCoef);
    }



    private void check_suspension()
    {
        //Check Ground contact
        //Raycast for each wheel 
        RaycastHit hit;
        for (int i = 0; i < 4; i++)
        {

            if (Physics.Raycast(transform.TransformPoint(pos_Wheels[i]), -transform.up, out hit, max_spring_extension) )//&& Vector3.Dot(hit.normal, Vector3.up)>0.5)
            {
                isGrounded = true;
                f_wheels[i] = springK * 100 * (max_spring_extension - hit.distance) - springD * 100 * (hit.distance - y_wheels[i]);
                //Debug.DrawRay(transform.TransformPoint(pos_Wheels[i]), -transform.up*0.2f, Color.red);
                f_wheels[i] *= Vector3.Dot(hit.normal, Vector3.up);
                y_wheels[i] = hit.distance;
            }
            else
            {
                f_wheels[i] = 0;
            }
        }
    }

    private void groundMovement()
    {
        //Velocity to Local Frame
        vel = transform.InverseTransformDirection(body.velocity);

        //Handle Forward Acceleration (set to max speed when boosting)
        if(!boosting){
            if (Vector3.Dot(ground_normal, Vector3.up) > 0.7)
            {
                if (in_v > 0.1) vel.z += Vector3.Dot(ground_normal, Vector3.up) * acceleration * Time.deltaTime;
                else if (in_v < -0.1) vel.z -= Vector3.Dot(ground_normal, Vector3.up) * acceleration * Time.deltaTime;
                if (vel.z > max_speed) vel.z = max_speed;
                else if (vel.z < -max_speed) vel.z = -max_speed;
            }
        }else{
            vel.z = max_speed;
        }

        //Friction
        vel.z -= Mathf.Sign(vel.z) * Mathf.Min(friction * Time.deltaTime, Mathf.Abs(vel.z));
        vel.x -= Mathf.Sign(vel.x) * Mathf.Min(friction * 10 * Time.deltaTime, Mathf.Abs(vel.x));

        //slow down rotation speed to drive along minimal possible radius
        float v_min = rotation * 2 * Mathf.PI * min_radius / 360;
        float rot = rotation;
        if (Mathf.Abs(vel.z) < v_min)
        {
            rot = 360 * Mathf.Abs(vel.z) / (2 * Mathf.PI * min_radius);
        }

        //Rotate Player
        float dir = (vel.z < 0) ? -1 : 1;
        if (Mathf.Abs(vel.z) > 0.01) transform.Rotate(Vector3.up, in_h * dir * rot * Time.deltaTime);

        //Assign Velocity in World Frame
        body.velocity = transform.TransformDirection(vel);


        //Angular Velocity/Friction
        Vector3 ang = transform.InverseTransformDirection(body.angularVelocity);

        if (ang.magnitude < 0.001)
        {
            ang = Vector3.zero;
        }
        else
        {
            //Rotational  Friction
            ang.y -= ang.y * friction / 10;

            //smooth out the board wobble
            ang.x -= ang.x * 0.1f;
            ang.z -= ang.z * 0.1f;
        }

        body.angularVelocity = transform.TransformDirection(ang);

        //Apply suspension forces:
        for (int i = 0; i < 4; i++)
        {
            body.AddForceAtPosition(transform.up * f_wheels[i], transform.TransformPoint(pos_Wheels[i]));
        }
    }
    private void airMovement()
    {
        //Player Control during flight
        float dir = (vel.z < 0) ? -1 : 1;
        transform.Rotate(Vector3.up, in_h * dir * rotation * Time.deltaTime);

        //dampen rotation 
        Vector3 ang = transform.InverseTransformDirection(body.angularVelocity);
        ang.x -= ang.x * 0.2f;
        ang.z -= ang.z * 0.1f;
        body.angularVelocity = transform.TransformDirection(ang);
    }

    //Boost platform for lvl 3
    public void lvl3Boost(){
        this.max_speed = 20;
        this.boosting = true;
        
    }
    public void lvl3Boostreset(){
        this.max_speed = 10;
        this.boosting = false;
    }
}
