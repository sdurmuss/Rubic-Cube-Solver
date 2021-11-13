using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Buttons : MonoBehaviour
{
    public void next()
    {
        if (GameObject.Find("GameController").GetComponent<Game>().isCubeCorrect() == true)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
    public void PlayGame1()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void PlayGame2()
    {
        SceneManager.LoadScene("CubeSelect");
    }
    public void ReturnToMainMenu()
    {
        try
        {
            Destroy(GameObject.Find("GameController"));
        }
        catch{}
        SceneManager.LoadScene("MainMenu");
    }
    public void closeGame()
    {
        Application.Quit();
    }
    public void left()
    {
        GameObject.Find("Cube").GetComponent<Rotations>().left();
    }
    public void leftR()
    {
        GameObject.Find("Cube").GetComponent<Rotations>().left(false);
    }
    public void right()
    {
        GameObject.Find("Cube").GetComponent<Rotations>().right();
    }
    public void rightR()
    {
        GameObject.Find("Cube").GetComponent<Rotations>().right(false);
    }
    public void up()
    {
        GameObject.Find("Cube").GetComponent<Rotations>().up();
    }
    public void upR()
    {
        GameObject.Find("Cube").GetComponent<Rotations>().up(false);
    }
    public void down()
    {
        GameObject.Find("Cube").GetComponent<Rotations>().down();
    }
    public void downR()
    {
        GameObject.Find("Cube").GetComponent<Rotations>().down(false);
    }
    public void front()
    {
        GameObject.Find("Cube").GetComponent<Rotations>().front();
    }
    public void frontR()
    {
        GameObject.Find("Cube").GetComponent<Rotations>().front(false);
    }
    public void back()
    {
        GameObject.Find("Cube").GetComponent<Rotations>().back();
    }
    public void backR()
    {
        GameObject.Find("Cube").GetComponent<Rotations>().back(false);
    }
    public void scramble()
    {
        System.Random rnd = new System.Random();
        for (int i = 0; i < 25; i++)
        {
            int a = rnd.Next(0, 6);
            move(a);
            GameObject.Find("GameController2").GetComponent<Game2>().moveCount = -1;
            GameObject.Find("GameController2").GetComponent<Game2>().text();
            GameObject.Find("GameController2").GetComponent<Game2>().moveList = "";
            //Destroy(GameObject.Find("Scramble"));
        }
        void move(int a)
        {
            if (a==0)
            {
                GameObject.Find("Cube").GetComponent<Rotations>().left();
            }
            else if (a == 1) 
            {
                GameObject.Find("Cube").GetComponent<Rotations>().right();
            }
            else if (a == 2) 
            {
                GameObject.Find("Cube").GetComponent<Rotations>().up();
            }
            else if (a == 3) 
            {
                GameObject.Find("Cube").GetComponent<Rotations>().down();
            }
            else if (a == 4) 
            {
                GameObject.Find("Cube").GetComponent<Rotations>().front();
            }
            else
            {
                GameObject.Find("Cube").GetComponent<Rotations>().back();
            }
        }
    }
    public void solve()
    {
        GameObject.Find("Cube").GetComponent<Solve>().whiteCross();
        //Destroy(GameObject.Find("Solve"));
    }
    public void closeDialog()
    {
        Destroy(GameObject.Find("Dialog(Clone)"));
    }
}
