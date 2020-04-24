using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller1 : MonoBehaviour
{
    public void checkMission()
    {
        GameController.controller.NextFase();
    }
}
