using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameObject controller = GameObject.Find("GameController");
        controller.GetComponent<Game>().selectedMaterial = GetComponent<Renderer>().material;
    }
}
