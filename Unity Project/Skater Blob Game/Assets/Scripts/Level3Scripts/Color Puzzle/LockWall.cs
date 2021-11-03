using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockWall : MonoBehaviour
{   

    //Trigger for the walls that resets the puzzle on collision

    public ColorPuzzlecont cont;

    private void OnTriggerEnter(Collider other)
    {
        cont.resetpuzzle();
    }
}
