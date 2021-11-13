using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game2 : MonoBehaviour
{
    public char[,] white = new char[,] { { 'W', 'W', 'W' }, { 'W', 'W', 'W' }, { 'W', 'W', 'W' } };
    public char[,] yellow = new char[,] { { 'Y', 'Y', 'Y' }, { 'Y', 'Y', 'Y' }, { 'Y', 'Y', 'Y' } };
    public char[,] blue = new char[,] { { 'B', 'B', 'B' }, { 'B', 'B', 'B' }, { 'B', 'B', 'B' } };
    public char[,] red = new char[,] { { 'R', 'R', 'R' }, { 'R', 'R', 'R' }, { 'R', 'R', 'R' } };
    public char[,] green = new char[,] { { 'G', 'G', 'G' }, { 'G', 'G', 'G' }, { 'G', 'G', 'G' } };
    public char[,] orange = new char[,] { { 'O', 'O', 'O' }, { 'O', 'O', 'O' }, { 'O', 'O', 'O' } };

    public char Front = 'O';
    public char Back = 'R';
    public char Up = 'Y';
    public char Down = 'W';
    public char Left = 'G';
    public char Right = 'B';
    public int moveCount = 0;
    public string moveList = "";


    bool isCubeSolved()
    {
        if (!check(white))
            return false;
        if (!check(yellow))
            return false;
        if (!check(orange))
            return false;
        if (!check(red))
            return false;
        if (!check(blue))
            return false;
        if (!check(green))
            return false;
        try
        {
            GameObject.Find("Play").SetActive(false);
        }
        catch (System.Exception)
        {
        }
        return true;
    }
    public bool check(char[,] list)
    {
        foreach (var item in list)
        {
            if (item != list[1,1])
                return false;
        }
        return true;
    }
    public void text()
    {
        moveCount++;
        GameObject.Find("Move").transform.GetComponent<TMPro.TextMeshProUGUI>().text = ""+moveCount;
        GameObject.Find("Moves").transform.GetComponent<TMPro.TextMeshProUGUI>().text = moveList;
    }
    void Start()
    {
        try
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    white[i, j] = GameObject.Find("GameController").GetComponent<Game>().white[i, j];
                    red[i, j] = GameObject.Find("GameController").GetComponent<Game>().red[i, j];
                    yellow[i, j] = GameObject.Find("GameController").GetComponent<Game>().yellow[i, j];
                    green[i, j] = GameObject.Find("GameController").GetComponent<Game>().green[i, j];
                    orange[i, j] = GameObject.Find("GameController").GetComponent<Game>().orange[i, j];
                    blue[i, j] = GameObject.Find("GameController").GetComponent<Game>().blue[i, j];
                }
            }
            Destroy(GameObject.Find("GameController"));
            Destroy(GameObject.Find("Play"));
            Destroy(GameObject.Find("Scramble"));
        }
        catch (System.Exception)
        {
            //Destroy(GameObject.Find("Solve"));
        }
        GameObject.Find("CubeMap").GetComponent<Map>().mapUpdate();
    }
    public void LeftSwipe()
    {
        char temp = Front;
        Front = Right;
        Right = Back;
        Back = Left;
        Left = temp;
    }
    public void RightSwipe()
    {
        char temp = Front;
        Front = Left;
        Left = Back;
        Back = Right;
        Right = temp;
    }
    public void UpLeftSwipe()
    {
        char temp = Right;
        Right = Down;
        Down = Left;
        Left = Up;
        Up = temp;
    }
    public void UpRightSwipe()
    {
        char temp = Front;
        Front = Down;
        Down = Back;
        Back = Up;
        Up = temp;
    }
    public void DownLeftSwipe()
    {
        char temp = Front;
        Front = Up;
        Up = Back;
        Back = Down;
        Down = temp;
    }
    public void DownRightSwipe() 
    {
        char temp = Right;
        Right = Up;
        Up = Left;
        Left = Down;
        Down = temp;
    }
    public char[,] Side(char side=' ')
    {
        if (side == 'O')
        {
            return orange;
        }
        else if (side == 'R')
        {
            return red;
        }
        else if (side == 'G')
        {
            return green;
        }
        else if (side == 'B')
        {
            return blue;
        }
        else if (side == 'W')
        {
            return white;
        }
        else
        {
            return yellow;
        }
    }
    public void right(bool a)
    {
        text();
        char temp1 = Side(Front)[0, 2];
        char temp2 = Side(Front)[1, 2];
        char temp3 = Side(Front)[2, 2];
        if (a)
        {
            Side(Front)[0, 2] = Side(Down)[0, 2];
            Side(Front)[1, 2] = Side(Down)[1, 2];
            Side(Front)[2, 2] = Side(Down)[2, 2];

            Side(Down)[0, 2] = Side(Back)[2, 0];
            Side(Down)[1, 2] = Side(Back)[1, 0];
            Side(Down)[2, 2] = Side(Back)[0, 0];

            Side(Back)[2, 0] = Side(Up)[0, 2];
            Side(Back)[1, 0] = Side(Up)[1, 2];
            Side(Back)[0, 0] = Side(Up)[2, 2];

            Side(Up)[0, 2] = temp1;
            Side(Up)[1, 2] = temp2;
            Side(Up)[2, 2] = temp3;
        }
        else
        {
            Side(Front)[0, 2] = Side(Up)[0, 2];
            Side(Front)[1, 2] = Side(Up)[1, 2];
            Side(Front)[2, 2] = Side(Up)[2, 2];

            Side(Up)[0, 2] = Side(Back)[2, 0];
            Side(Up)[1, 2] = Side(Back)[1, 0];
            Side(Up)[2, 2] = Side(Back)[0, 0];

            Side(Back)[2, 0] = Side(Down)[0, 2];
            Side(Back)[1, 0] = Side(Down)[1, 2];
            Side(Back)[0, 0] = Side(Down)[2, 2];

            Side(Down)[0, 2] = temp1;
            Side(Down)[1, 2] = temp2;
            Side(Down)[2, 2] = temp3;
        }
        oneSideRotate(Side(Right), a);
        GameObject.Find("CubeMap").GetComponent<Map>().mapUpdate();
        isCubeSolved();
    }
    public void left(bool a)
    {
        text();
        char temp1 = Side(Front)[0, 0];
        char temp2 = Side(Front)[1, 0];
        char temp3 = Side(Front)[2, 0];
        if (a)
        {
            Side(Front)[0, 0] = Side(Up)[0, 0];
            Side(Front)[1, 0] = Side(Up)[1, 0];
            Side(Front)[2, 0] = Side(Up)[2, 0];

            Side(Up)[0, 0] = Side(Back)[2, 2];
            Side(Up)[1, 0] = Side(Back)[1, 2];
            Side(Up)[2, 0] = Side(Back)[0, 2];

            Side(Back)[2, 2] = Side(Down)[0,0];
            Side(Back)[1, 2] = Side(Down)[1,0];
            Side(Back)[0, 2] = Side(Down)[2,0];

            Side(Down)[0, 0] = temp1;
            Side(Down)[1, 0] = temp2;
            Side(Down)[2, 0] = temp3;
        }
        else
        {
            Side(Front)[0, 0] = Side(Down)[0, 0];
            Side(Front)[1, 0] = Side(Down)[1, 0];
            Side(Front)[2, 0] = Side(Down)[2, 0];

            Side(Down)[0, 0] = Side(Back)[2, 2];
            Side(Down)[1, 0] = Side(Back)[1, 2];
            Side(Down)[2, 0] = Side(Back)[0, 2];

            Side(Back)[2, 2] = Side(Up)[0, 0];
            Side(Back)[1, 2] = Side(Up)[1, 0];
            Side(Back)[0, 2] = Side(Up)[2, 0];

            Side(Up)[0, 0] = temp1;
            Side(Up)[1, 0] = temp2;
            Side(Up)[2, 0] = temp3;
        }
        oneSideRotate(Side(Left), a);
        GameObject.Find("CubeMap").GetComponent<Map>().mapUpdate();
        isCubeSolved();
    }
    public void up(bool a)
    {
        text();
        char temp1= Side(Front)[0, 0];
        char temp2= Side(Front)[0, 1];
        char temp3= Side(Front)[0, 2];
        if (a)
        {
            Side(Front)[0, 0] = Side(Right)[0, 0];
            Side(Front)[0, 1] = Side(Right)[0, 1];
            Side(Front)[0, 2] = Side(Right)[0, 2];

            Side(Right)[0, 0] = Side(Back)[0, 0];
            Side(Right)[0, 1] = Side(Back)[0, 1];
            Side(Right)[0, 2] = Side(Back)[0, 2];

            Side(Back)[0, 0] = Side(Left)[0, 0];
            Side(Back)[0, 1] = Side(Left)[0, 1];
            Side(Back)[0, 2] = Side(Left)[0, 2];

            Side(Left)[0, 0] = temp1;
            Side(Left)[0, 1] = temp2;
            Side(Left)[0, 2] = temp3;
        }
        else
        {
            Side(Front)[0, 0] = Side(Left)[0, 0];
            Side(Front)[0, 1] = Side(Left)[0, 1];
            Side(Front)[0, 2] = Side(Left)[0, 2];

            Side(Left)[0, 0] = Side(Back)[0, 0];
            Side(Left)[0, 1] = Side(Back)[0, 1];
            Side(Left)[0, 2] = Side(Back)[0, 2];

            Side(Back)[0, 0] = Side(Right)[0, 0];
            Side(Back)[0, 1] = Side(Right)[0, 1];
            Side(Back)[0, 2] = Side(Right)[0, 2];

            Side(Right)[0, 0] = temp1;
            Side(Right)[0, 1] = temp2;
            Side(Right)[0, 2] = temp3;
        }
        oneSideRotate(Side(Up), a);
        GameObject.Find("CubeMap").GetComponent<Map>().mapUpdate();
        isCubeSolved();
    }
    public void down(bool a)
    {
        text();
        char temp1 = Side(Front)[2, 0];
        char temp2 = Side(Front)[2, 1];
        char temp3 = Side(Front)[2, 2];
        if (a)
        {
            Side(Front)[2, 0] = Side(Left)[2, 0];
            Side(Front)[2, 1] = Side(Left)[2, 1];
            Side(Front)[2, 2] = Side(Left)[2, 2];

            Side(Left)[2, 0] = Side(Back)[2, 0];
            Side(Left)[2, 1] = Side(Back)[2, 1];
            Side(Left)[2, 2] = Side(Back)[2, 2];

            Side(Back)[2, 0] = Side(Right)[2, 0];
            Side(Back)[2, 1] = Side(Right)[2, 1];
            Side(Back)[2, 2] = Side(Right)[2, 2];

            Side(Right)[2, 0] = temp1;
            Side(Right)[2, 1] = temp2;
            Side(Right)[2, 2] = temp3;
        }
        else
        {
            Side(Front)[2, 0] = Side(Right)[2, 0];
            Side(Front)[2, 1] = Side(Right)[2, 1];
            Side(Front)[2, 2] = Side(Right)[2, 2];

            Side(Right)[2, 0] = Side(Back)[2, 0];
            Side(Right)[2, 1] = Side(Back)[2, 1];
            Side(Right)[2, 2] = Side(Back)[2, 2];

            Side(Back)[2, 0] = Side(Left)[2, 0];
            Side(Back)[2, 1] = Side(Left)[2, 1];
            Side(Back)[2, 2] = Side(Left)[2, 2];

            Side(Left)[2, 0] = temp1;
            Side(Left)[2, 1] = temp2;
            Side(Left)[2, 2] = temp3;
        }
        oneSideRotate(Side(Down), a);
        GameObject.Find("CubeMap").GetComponent<Map>().mapUpdate();
        isCubeSolved();
    }
    public void front(bool a)
    {
        text();
        char temp1 = Side(Up)[2, 0];
        char temp2 = Side(Up)[2, 1];
        char temp3 = Side(Up)[2, 2];
        if (a)
        {
            Side(Up)[2, 2] = Side(Left)[0, 2];
            Side(Up)[2, 1] = Side(Left)[1, 2];
            Side(Up)[2, 0] = Side(Left)[2, 2];

            Side(Left)[0, 2] = Side(Down)[0, 0];
            Side(Left)[1, 2] = Side(Down)[0, 1];
            Side(Left)[2, 2] = Side(Down)[0, 2];

            Side(Down)[0, 0] = Side(Right)[2, 0];
            Side(Down)[0, 1] = Side(Right)[1, 0];
            Side(Down)[0, 2] = Side(Right)[0, 0];

            Side(Right)[2, 0] = temp3;
            Side(Right)[1, 0] = temp2;
            Side(Right)[0, 0] = temp1;
        }
        else
        {
            Side(Up)[2, 0] = Side(Right)[0, 0];
            Side(Up)[2, 1] = Side(Right)[1, 0];
            Side(Up)[2, 2] = Side(Right)[2, 0];

            Side(Right)[0, 0] = Side(Down)[0, 2];
            Side(Right)[1, 0] = Side(Down)[0, 1];
            Side(Right)[2, 0] = Side(Down)[0, 0];

            Side(Down)[0, 2] = Side(Left)[2, 2];
            Side(Down)[0, 1] = Side(Left)[1, 2];
            Side(Down)[0, 0] = Side(Left)[0, 2];

            Side(Left)[2, 2] = temp1;
            Side(Left)[1, 2] = temp2;
            Side(Left)[0, 2] = temp3;

        }
        oneSideRotate(Side(Front), a);
        GameObject.Find("CubeMap").GetComponent<Map>().mapUpdate();
        isCubeSolved();
    }
    public void back(bool a)
    {
        text();
        char temp1 = Side(Up)[0, 0];
        char temp2 = Side(Up)[0, 1];
        char temp3 = Side(Up)[0, 2];
        if (a)
        {
            Side(Up)[0, 0] = Side(Right)[0, 2];
            Side(Up)[0, 1] = Side(Right)[1, 2];
            Side(Up)[0, 2] = Side(Right)[2, 2];

            Side(Right)[0, 2] = Side(Down)[2,2];
            Side(Right)[1, 2] = Side(Down)[2,1];
            Side(Right)[2, 2] = Side(Down)[2,0];

            Side(Down)[2, 2] = Side(Left)[2,0];
            Side(Down)[2, 1] = Side(Left)[1,0];
            Side(Down)[2, 0] = Side(Left)[0,0];

            Side(Left)[2, 0] = temp1;
            Side(Left)[1, 0] = temp2;
            Side(Left)[0, 0] = temp3;
        }
        else
        {
            Side(Up)[0, 0] = Side(Left)[2,0];
            Side(Up)[0, 1] = Side(Left)[1,0];
            Side(Up)[0, 2] = Side(Left)[0,0];

            Side(Left)[2, 0] = Side(Down)[2,2];
            Side(Left)[1, 0] = Side(Down)[2,1];
            Side(Left)[0, 0] = Side(Down)[2,0];

            Side(Down)[2, 2] = Side(Right)[0,2];
            Side(Down)[2, 1] = Side(Right)[1,2];
            Side(Down)[2, 0] = Side(Right)[2,2];

            Side(Right)[0, 2] = temp1;
            Side(Right)[1, 2] = temp2;
            Side(Right)[2, 2] = temp3;
        }
        oneSideRotate(Side(Back), a);
        GameObject.Find("CubeMap").GetComponent<Map>().mapUpdate();
        isCubeSolved();
    }
    public void oneSideRotate(char[,] side,bool a)
    {
        if (a)
        {
            char temp = side[0, 0];
            side[0, 0] = side[2, 0];
            side[2, 0] = side[2, 2];
            side[2, 2] = side[0, 2];
            side[0, 2] = temp;

            temp = side[0, 1];
            side[0, 1] = side[1, 0];
            side[1, 0] = side[2, 1];
            side[2, 1] = side[1, 2];
            side[1, 2] = temp;
        }
        else
        {
            char temp = side[0, 0];
            side[0, 0] = side[0, 2];
            side[0, 2] = side[2, 2];
            side[2, 2] = side[2, 0];
            side[2, 0] = temp;

            temp = side[0, 1];
            side[0, 1] = side[1, 2];
            side[1, 2] = side[2, 1];
            side[2, 1] = side[1, 0];
            side[1, 0] = temp;
        }
    }
}

