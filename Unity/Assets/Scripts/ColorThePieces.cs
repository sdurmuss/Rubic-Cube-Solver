using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorThePieces : MonoBehaviour
{

    [SerializeField]
    char side;
    [SerializeField]
    int index;
    private void Start()
    {
        StartCoroutine(color());
        
    }
    IEnumerator color()
    {
        yield return new WaitForSeconds(0.01f);
        if (side == 'f')
        {
            transform.GetComponent<Renderer>().material.SetColor("_Color", colorFinder(GameObject.Find("GameController2").GetComponent<Game2>().orange[index / 3, index % 3]));
        }
        else if (side == 'b')
        {
            transform.GetComponent<Renderer>().material.SetColor("_Color", colorFinder(GameObject.Find("GameController2").GetComponent<Game2>().red[index / 3, index % 3]));
        }
        else if (side == 'u')
        {
            transform.GetComponent<Renderer>().material.SetColor("_Color", colorFinder(GameObject.Find("GameController2").GetComponent<Game2>().yellow[index / 3, index % 3]));
        }
        else if (side == 'd')
        {
            transform.GetComponent<Renderer>().material.SetColor("_Color", colorFinder(GameObject.Find("GameController2").GetComponent<Game2>().white[index / 3, index % 3]));
        }
        else if (side == 'l')
        {
            transform.GetComponent<Renderer>().material.SetColor("_Color", colorFinder(GameObject.Find("GameController2").GetComponent<Game2>().green[index / 3, index % 3]));
        }
        else if (side == 'r')
        {
            transform.GetComponent<Renderer>().material.SetColor("_Color", colorFinder(GameObject.Find("GameController2").GetComponent<Game2>().blue[index / 3, index % 3]));
        }
    }

    Color colorFinder(char color)
    {
        if (color == 'W')
        {
            return GameObject.Find("CubeMap").GetComponent<Map>().white.color;
        }
        else if (color == 'Y')
        {
            return GameObject.Find("CubeMap").GetComponent<Map>().yellow.color;
        }
        else if (color == 'B')
        {
            return GameObject.Find("CubeMap").GetComponent<Map>().blue.color;
        }
        else if (color == 'R')
        {
            return GameObject.Find("CubeMap").GetComponent<Map>().red.color;
        }
        else if (color == 'G')
        {
            return GameObject.Find("CubeMap").GetComponent<Map>().green.color;
        }
        else if(color == 'O')
        {
            return GameObject.Find("CubeMap").GetComponent<Map>().orange.color;
        }
        else
        {
            return new Color(0f, 0f, 0f, 255f);
        }
    }
}
