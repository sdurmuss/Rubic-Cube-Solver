using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public Material white;
    public Material red;
    public Material green;
    public Material blue;
    public Material orange;
    public Material yellow;

    public void mapUpdate()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject obj = this.transform.GetChild(i).gameObject;
            for (int j = 0; j < obj.transform.childCount; j++)
            {
                obj.transform.GetChild(j).GetComponent<Image>().color = mtr(j, i).color;
            }
        }
    }
    Material mtr(int i,int j)
    {
        GameObject temp = GameObject.Find("GameController2");
        char a;
        if (transform.GetChild(j).name == "Up")
        {
            a = temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Up)[i / 3, i % 3];
        }
        else if (transform.GetChild(j).name == "Front")
        {
            a = temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Front)[i / 3, i % 3];
        }
        else if (transform.GetChild(j).name == "Down")
        {
            a = temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Down)[i / 3, i % 3];
        }
        else if (transform.GetChild(j).name == "Right")
        {
            a = temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Right)[i / 3, i % 3];
        }
        else if (transform.GetChild(j).name == "Left")
        {
            a = temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Left)[i / 3, i % 3];
        }
        else
        {
            a = temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Back)[i / 3, i % 3];
        }
        if (a == 'W')
        {
            return white;
        }
        else if (a == 'R')
        {
            return red;
        }
        else if (a == 'G')
        {
            return green;
        }
        else if (a == 'Y')
        {
            return yellow;
        }
        else if (a == 'B')
        {
            return blue;
        }
        else
        {
            return orange;
        }
    }
}
