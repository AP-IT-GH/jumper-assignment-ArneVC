using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void ResetWalls()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("DangerWall");
        foreach (GameObject wall in walls)
        {
            Destroy(wall);
        }
    }
}
