using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMenu : MonoBehaviour
{
    public Canvas canv;

    Animator ani;

    private void Start()
    {
        canv.enabled = false;
        ani = GetComponent<Animator>();
    }
    public void ShowMenuUI()
    {
        canv.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && canv.enabled == false)
        {
            canv.enabled = true;
            ani.Play("Camera", 0, 1f);
        }
    }
}
