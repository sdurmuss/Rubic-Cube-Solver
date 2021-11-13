using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotations : MonoBehaviour
{
    public GameObject center;

    private void Start()
    {
        //StartCoroutine(rotate());
    }  
    IEnumerator rotate()
    {
        yield return new WaitForSeconds(5);
        back();

        yield return new WaitForSeconds(1);
        left();

        yield return new WaitForSeconds(1);
        up(false);

        yield return new WaitForSeconds(1);
        right();
    }
    void Update()
    {
        /*foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Pieces"))
        {
            if (check(cube.GetComponent<Piece>().tags, "u"))
            {
                cube.transform.RotateAround(center.transform.position, -transform.parent.up, 90 *Time.deltaTime);
            }
        }*/
    }
    bool check(string[] asd,string a)
    {
        foreach (var item in asd)
        {
            if (item == a)
                return true;
        }
        return false;
    }
    void change(GameObject cube, char rotation, bool a)
    {
        if (rotation=='u')
        {
            for (int i=0; i < cube.GetComponent<Piece>().tags.Length;i++)
            {
                switch (cube.GetComponent<Piece>().tags[i])
                {
                    case "r":
                        cube.GetComponent<Piece>().tags[i] =  a == true ? "f" : "b";
                        break;
                    case "f":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "l" : "r";
                        break;
                    case "l":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "b" : "f";
                        break;
                    case "b":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "r" : "l";
                        break;
                    default:
                        break;
                }
            }
        }
        else if(rotation == 'd') 
        {
            for (int i = 0; i < cube.GetComponent<Piece>().tags.Length; i++)
            {
                switch (cube.GetComponent<Piece>().tags[i])
                {
                    case "r":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "b" : "f";
                        break;
                    case "f":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "r" : "l";
                        break;
                    case "l":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "f" : "b";
                        break;
                    case "b":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "l" : "r";
                        break;
                    default:
                        break;
                }
            }
        }
        else if(rotation == 'l') 
        {
            for (int i = 0; i < cube.GetComponent<Piece>().tags.Length; i++)
            {
                switch (cube.GetComponent<Piece>().tags[i])
                {
                    case "d":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "b" : "f";
                        break;
                    case "f":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "d" : "u";
                        break;
                    case "u":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "f" : "b";
                        break;
                    case "b":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "u" : "d";
                        break;
                    default:
                        break;
                }
            }
        }
        else if(rotation == 'r') 
        {
            for (int i = 0; i < cube.GetComponent<Piece>().tags.Length; i++)
            {
                switch (cube.GetComponent<Piece>().tags[i])
                {
                    case "d":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "f" : "b";
                        break;
                    case "f":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "u" : "d";
                        break;
                    case "u":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "b" : "f";
                        break;
                    case "b":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "d" : "u";
                        break;
                    default:
                        break;
                }
            }
        }
        else if(rotation == 'f') 
        {
            for (int i = 0; i < cube.GetComponent<Piece>().tags.Length; i++)
            {
                switch (cube.GetComponent<Piece>().tags[i])
                {
                    case "u":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "r" : "l";
                        break;
                    case "r":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "d" : "u";
                        break;
                    case "d":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "l" : "r";
                        break;
                    case "l":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "u" : "d";
                        break;
                    default:
                        break;
                }
            }
        }
        else //back 
        {
            for (int i = 0; i < cube.GetComponent<Piece>().tags.Length; i++)
            {
                switch (cube.GetComponent<Piece>().tags[i])
                {
                    case "u":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "l" : "r";
                        break;
                    case "r":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "u" : "d";
                        break;
                    case "d":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "r" : "l";
                        break;
                    case "l":
                        cube.GetComponent<Piece>().tags[i] = a == true ? "d" : "u";
                        break;
                    default:
                        break;
                }
            }
        }
    }
    //Sağ Tarafı Çevirme. true = saat yönü, false = saat yönü tersi.
    public void right(bool a = true) {
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Pieces"))
        {
            if (check(cube.GetComponent<Piece>().tags, "r"))
            {
                cube.transform.RotateAround(center.transform.position, -transform.parent.forward * (a==true ? 1 : -1), 90);
                change(cube, 'r', a);
            }
        }
        GameObject.Find("GameController2").GetComponent<Game2>().right(a);
    }
    //Sol Tarafı Çevirme. true = saat yönü, false = saat yönü tersi.
    public void left(bool a = true) {
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Pieces"))
        {
            if (check(cube.GetComponent<Piece>().tags, "l"))
            {
                cube.transform.RotateAround(center.transform.position, transform.parent.forward * (a == true ? 1 : -1), 90);
                change(cube, 'l', a);
            }
        }
        GameObject.Find("GameController2").GetComponent<Game2>().left(a);
    }
    //Yukarı Tarafı Çevirme. true = saat yönü, false = saat yönü tersi.
    public void up(bool a = true)
    {
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Pieces"))
        {
            if (check(cube.GetComponent<Piece>().tags, "u"))
            {
                cube.transform.RotateAround(center.transform.position, transform.parent.up * (a == true ? 1 : -1), 90);
                change(cube, 'u', a);
            }
        }
        GameObject.Find("GameController2").GetComponent<Game2>().up(a);
    }
    //Aşağı Tarafı Çevirme. true = saat yönü, false = saat yönü tersi.
    public void down(bool a = true)
    {
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Pieces"))
        {
            if (check(cube.GetComponent<Piece>().tags, "d"))
            {
                cube.transform.RotateAround(center.transform.position, -transform.parent.up * (a == true ? 1 : -1), 90);
                change(cube, 'd', a);
            }
        }
        GameObject.Find("GameController2").GetComponent<Game2>().down(a);
    }
    //Ön Tarafı Çevirme. true = saat yönü, false = saat yönü tersi.
    public void front(bool a = true)
    {
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Pieces"))
        {
            if (check(cube.GetComponent<Piece>().tags, "f"))
            {
                cube.transform.RotateAround(center.transform.position, -transform.parent.right * (a == true ? 1 : -1), 90);
                change(cube, 'f', a);
            }
        }
        GameObject.Find("GameController2").GetComponent<Game2>().front(a);
    }
    //Back Tarafı Çevirme. true = saat yönü, false = saat yönü tersi.
    public void back(bool a = true)
    {
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Pieces"))
        {
            if (check(cube.GetComponent<Piece>().tags, "b"))
            {
                cube.transform.RotateAround(center.transform.position, transform.parent.right * (a == true ? 1 : -1), 90);
                change(cube, 'b', a);
            }
        }
        GameObject.Find("GameController2").GetComponent<Game2>().back(a);
    }
}
