using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject restartMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            restartMenu.SetActive(true);
        }
    }
}