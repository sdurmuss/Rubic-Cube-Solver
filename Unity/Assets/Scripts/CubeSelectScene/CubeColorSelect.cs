using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeColorSelect : MonoBehaviour
{
    private void OnMouseDown()
    {
        Material mtr = GameObject.Find("GameController").GetComponent<Game>().selectedMaterial;
        GetComponent<Renderer>().material = mtr;
        int place = Convert.ToInt32(this.name);
        switch (transform.parent.name)
        {
            case "Yellow":
                GameObject.Find("GameController").GetComponent<Game>().yellow[Convert.ToInt32(place / 3),place%3] = mtr.name[0];
                break;

            case "White":
                GameObject.Find("GameController").GetComponent<Game>().white[place / 3, place % 3] = mtr.name[0];
                break;

            case "Blue":
                GameObject.Find("GameController").GetComponent<Game>().blue[place / 3, place % 3] = mtr.name[0];
                break;

            case "Red":
                GameObject.Find("GameController").GetComponent<Game>().red[place / 3, place % 3] = mtr.name[0];
                break;

            case "Green":
                GameObject.Find("GameController").GetComponent<Game>().green[place / 3, place % 3] = mtr.name[0];
                break;

            case "Orange":
                GameObject.Find("GameController").GetComponent<Game>().orange[place / 3, place % 3] = mtr.name[0];
                break;

            default:
                break;
        }
    }
}
