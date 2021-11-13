using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    public Material selectedMaterial;
    public char[,] white = new char[,] { { 'W', 'W', 'W' }, { 'W', 'W', 'W' }, { 'W', 'W', 'W' } };
    public char[,] yellow = new char[,] { { 'W', 'W', 'W' }, { 'W', 'Y', 'W' }, { 'W', 'W', 'W' } };
    public char[,] blue = new char[,] { { 'W', 'W', 'W' }, { 'W', 'B', 'W' }, { 'W', 'W', 'W' } };
    public char[,] red = new char[,] { { 'W', 'W', 'W' }, { 'W', 'R', 'W' }, { 'W', 'W', 'W' } };
    public char[,] green = new char[,] { { 'W', 'W', 'W' }, { 'W', 'G', 'W' }, { 'W', 'W', 'W' } };
    public char[,] orange = new char[,] { { 'W', 'W', 'W' }, { 'W', 'O', 'W' }, { 'W', 'W', 'W' } };

    [SerializeField]
    GameObject dialog;

    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //Sıra sıra kontrolleri gerçekleştiriyor.
    public bool isCubeCorrect()
    {
        if (false == calculatePieces())
        {
            Debug.Log("Çözülemez Küp..: Her renkten 9 tane olmak zorunda."); 
            Instantiate(dialog, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject.Find("ErrorText").transform.GetComponent<TMPro.TextMeshProUGUI>().text = "Çözülemez Küp \nHer renkten 9 tane olmak zorunda.";
            return false;
        }
        if (false == incorrectCorner())
        {
            Debug.Log("Çözülemez Küp..: Köşe parçalarının renkleri yanlış.");
            Instantiate(dialog, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject.Find("ErrorText").transform.GetComponent<TMPro.TextMeshProUGUI>().text = "Çözülemez Küp\nKöşe parçalarının renkleri yanlış.";
            return false;
        }
        if (false == cornerTwist())
        {
            Debug.Log("Çözülemez Küp..: Köşe parçalarının oryantasyonu yanlış.");
            Instantiate(dialog, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject.Find("ErrorText").transform.GetComponent<TMPro.TextMeshProUGUI>().text = "Çözülemez Küp\nKöşe parçalarının oryantasyonu yanlış.";
            return false;
        }
        if (false == isEdgesCorrect())
        {
            Debug.Log("Çözülemez Küp..: Kenar parçalarının oryantasyonu yanlış.");
            Instantiate(dialog, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject.Find("ErrorText").transform.GetComponent<TMPro.TextMeshProUGUI>().text = "Çözülemez Küp\nKenar parçalarının oryantasyonu yanlış.";
            return false;
        }
        Debug.Log("Küp Doğrudur.");
        return true;
    }

    //Her renkten 9 tane var mı kontrol.
    bool calculatePieces()
    {
        int wCount = 0;
        int yCount = 0;
        int bCount = 0;
        int rCount = 0;
        int gCount = 0;
        int oCount = 0;
        count(white);
        count(yellow);
        count(blue);
        count(red);
        count(green);
        count(orange);
        if (wCount > 9 || yCount > 9 || bCount > 9 || gCount > 9 || rCount > 9 || oCount > 9)
        {
            Debug.Log("B..:" + bCount);
            Debug.Log("R..:" + rCount);
            Debug.Log("G..:" + gCount);
            Debug.Log("O..:" + oCount);
            Debug.Log("W..:" + wCount);
            Debug.Log("Y..:" + yCount);
            Debug.Log("Her Renkten 9 Tane Olmalı");
            return false;
        }
        else
        {
            Debug.Log("Doğru Giriş");
            return true;
        }
        //Gelen listedenin içinde hangi renk varsa, sayacı bir arttırıyor.
        void count(char[,] liste)
        {
            foreach (var item in liste)
            {
                switch (item)
                {
                    case 'W':
                        wCount++;
                        break;
                    case 'Y':
                        yCount++;
                        break;
                    case 'B':
                        bCount++;
                        break;
                    case 'R':
                        rCount++;
                        break;
                    case 'G':
                        gCount++;
                        break;
                    case 'O':
                        oCount++;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    //Toplam eğer 3e tam bölünüyorsa, köşe parçaları düzgün demektir.
    bool cornerTwist()
    {
        int count = 0;
        count += calculate(yellow[0,0],green[0,0],red[0,2]);
        count += calculate(yellow[0,2],red[0,0],blue[0,2]);
        count += calculate(yellow[2,0],orange[0,0],green[0,2]);
        count += calculate(yellow[2,2],blue[0,0],orange[0,2]);
        count += calculate(white[0,0],green[2,2],orange[2,0]);
        count += calculate(white[0,2],orange[2,2],blue[2,0]);
        count += calculate(white[2,0],red[2,2],green[2,0]);
        count += calculate(white[2,2],blue[2,2],red[2,0]);

        Debug.Log(count);
        if (count % 3 == 0 && count>=0)
            return true;
        return false;
    }

    //Köşe parçasında, beyaz veya sarının saat yönünde kalan renkten 2şer tane olmalı. Bir renkten 2den fazla varsa renkler yanlış girilmiştir.
    bool incorrectCorner()
    {
        List<char> deneme = new List<char>();
        deneme.Add(returnRight(yellow[0, 0], green[0, 0], red[0, 2]));
        deneme.Add(returnRight(yellow[0, 2], red[0, 0], blue[0, 2]));
        deneme.Add(returnRight(yellow[2, 0], orange[0, 0], green[0, 2]));
        deneme.Add(returnRight(yellow[2, 2], blue[0, 0], orange[0, 2]));
        deneme.Add(returnRight(white[0, 0], green[2, 2], orange[2, 0]));
        deneme.Add(returnRight(white[0, 2], orange[2, 2], blue[2, 0]));
        deneme.Add(returnRight(white[2, 0], red[2, 2], green[2, 0]));
        deneme.Add(returnRight(white[2, 2], blue[2, 2], red[2, 0]));
        int bCount = 0;
        int rCount = 0;
        int gCount = 0;
        int oCount = 0;

        foreach (var item in deneme)
        {
            if (item == 'B')
                bCount++;
            if (item == 'R')
                rCount++;
            if (item == 'G')
                gCount++;
            if (item == 'O')
                oCount++;
        }
        Debug.Log("Blue sayısı..:" + bCount);
        Debug.Log("Red sayısı..:" + rCount);
        Debug.Log("Green sayısı..:" + gCount);
        Debug.Log("Orange sayısı..:" + oCount);
        if (bCount == 2 && gCount == 2 && rCount == 2 && oCount == 2)
            return true;
        return false;
    }

    //Köşe parçasında, beyaz veya sarı yukarıdaysa 0, saat yönündeyse 1, saatin ters yönündeyse 2 döndürüyor.
    int calculate(char top, char right, char left)
    {
        if(top=='W' || top == 'Y')
        {
            return 0;
        }
        else if (right == 'W' || right == 'Y')
        {
            return 1;
        }
        else if (left == 'W' || left == 'Y')
        {
            return 2;
        }
        else
        {
            Debug.Log("Hata");
            return -20;
        }
    }

    //Köşe parçasında, beyaz veya sarı rengin saat yönünde kalan rengi döndürüyor.
    char returnRight(char top, char right, char left)
    {
        if (top == 'W' || top == 'Y')
        {
            return right;
        }
        else if (right == 'W' || right == 'Y')
        {
            return left;
        }
        else
        {
            return top;
        }
    }

    //Kenar parçaların oryantasyonlarını karşılaştırıyoruz, eşleşen değer tek ise küp hatalıdır.
    bool isEdgesCorrect()
    {
        int count = 0;
        char[,] asd ={ { 'O', 'G' }, { 'G', 'R' }, { 'R', 'B' }, { 'B', 'O' },{ 'W', 'B' },{ 'B', 'Y' },{ 'Y', 'G' },{ 'G', 'W' },{ 'W', 'R' },{ 'R', 'Y' },{ 'Y', 'O' },{ 'O', 'W' }};

        /*compareColors(orange[1,2],green[1,0]);
        compareColors(green[1,2],red[1,0]);
        compareColors(red[1,2],blue[1,0]);
        compareColors(blue[1,2],orange[1,0]);
        compareColors(white[1,2],blue[0,1]);
        compareColors(blue[2,1],yellow[1,2]);
        compareColors(yellow[1,0],green[2,1]);
        compareColors(green[0,1],white[1,0]);
        compareColors(white[2,1],red[0,1]);
        compareColors(red[2,1],yellow[0,1]);
        compareColors(yellow[2,1],orange[2,1]);
        compareColors(orange[0,1],white[0,1]);*/

        compareColors(red[1, 2], green[1, 0]);
        compareColors(green[1, 2], orange[1, 0]);
        compareColors(orange[1, 2], blue[1, 0]);
        compareColors(blue[1, 2], red[1, 0]);
        compareColors(yellow[1, 2], blue[0, 1]);
        compareColors(blue[2, 1], white[1, 2]);
        compareColors(white[1, 0], green[2, 1]);
        compareColors(green[0, 1], yellow[1, 0]);
        compareColors(yellow[2, 1], orange[0, 1]);
        compareColors(orange[2, 1], white[0, 1]);
        compareColors(white[2, 1], red[2, 1]);
        compareColors(red[0, 1], yellow[0, 1]);

        Debug.Log(count);
        void compareColors(char l, char r) //left,right
        {
            for (int i = 0; i < 12; i++)
            {
                if (asd[i,0] == l && asd[i,1]==r) 
                {
                    count++;
                    return;
                }
            }
        }

        if (count % 2 == 0)
            return true;
        return false;
    }
}