using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    Vector3 previousMousePosition;
    Vector3 mouseDelta;
    public GameObject target;
    float speed = 20000f;

    void Update()
    {
        Swipe();
        Drag();
    }
    void Drag()
    {
        if (Input.GetMouseButton(1))
        {
            mouseDelta = Input.mousePosition - previousMousePosition;
            mouseDelta *= 0.1f;
            transform.rotation = Quaternion.Euler(mouseDelta.y, -mouseDelta.x, 0) * transform.rotation;
        }
        else
        {
            if (transform.rotation != target.transform.rotation)
            {
                var step = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
                //transform.rotation = target.transform.rotation;
            }
        }
        previousMousePosition = Input.mousePosition;
    }
    public void Swipe()
    {
        if (Input.GetMouseButtonDown(1))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(1))
        {
            GameObject temp = GameObject.Find("GameController2");
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();
            if (LeftSwipe(currentSwipe))
            {
                doLeftSwipe();
            }
            else if (RightSwipe(currentSwipe))
            {
                doRightSwipe();
            }
            else if (UpLeftSwipe(currentSwipe))
            {
                target.transform.Rotate(90, 0, 0, Space.World);
                UpdatePieces(new string[] { "r", "u", "l", "d" });
                temp.GetComponent<Game2>().UpLeftSwipe();

                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Front), false);
                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Back), true);

                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Up), false);
                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Down), false);

                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Left), false);
                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Right), false);
            }
            else if (UpRightSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 0, -90, Space.World);
                UpdatePieces(new string[] { "f", "u", "b", "d" });
                temp.GetComponent<Game2>().UpRightSwipe();

                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Left), false);
                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Right), true);

                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Back), true);
                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Back), true);
                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Down), true);
                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Down), true);

            }
            else if (DownLeftSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 0, 90, Space.World);
                UpdatePieces(new string[] { "f", "d", "b", "u" });
                temp.GetComponent<Game2>().DownLeftSwipe();

                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Left), true);
                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Right), false);

                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Back), true);
                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Back), true);
                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Up), true);
                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Up), true);
            }
            else if (DownRightSwipe(currentSwipe))
            {
                target.transform.Rotate(-90, 0, 0, Space.World);
                UpdatePieces(new string[] { "r", "d", "l", "u" });
                temp.GetComponent<Game2>().DownRightSwipe();

                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Front), true);
                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Back), false);

                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Up), true);
                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Down), true);

                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Left), true);
                temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Right), true);
            }
            GameObject.Find("CubeMap").GetComponent<Map>().mapUpdate();
        }
    }
    bool LeftSwipe(Vector2 swipe)
    {
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
    bool RightSwipe(Vector2 swipe)
    {
        return currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
    bool UpLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0 && currentSwipe.x < 0f;
    }
    bool UpRightSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0 && currentSwipe.x > 0f;
    }
    bool DownLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0 && currentSwipe.x < 0f;
    }
    bool DownRightSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0 && currentSwipe.x > 0f;
    }
    //Her parça, hangi tarafta olduğu bilgisini tutuyor. Bu fonksiyon rotasyon yaptıktan sonra, bu bilgileri güncelliyor.
    void UpdatePieces(string [] deneme)
    {
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Pieces"))
        {
            for (int i = 0; i < cube.GetComponent<Piece>().tags.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (cube.GetComponent<Piece>().tags[i] == deneme[j])
                    {
                        cube.GetComponent<Piece>().tags[i] = deneme[(j + 1) % 4];
                        break;
                    }
                }
            }
        }
    }

    public void doLeftSwipe()
    {
        GameObject temp = GameObject.Find("GameController2");
        target.transform.Rotate(0, 90, 0, Space.World);
        UpdatePieces(new string[] { "f", "l", "b", "r" });
        temp.GetComponent<Game2>().LeftSwipe();
        temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Up), true);
        temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Down), false);
    }
    public void doRightSwipe()
    {
        GameObject temp = GameObject.Find("GameController2");
        target.transform.Rotate(0, -90, 0, Space.World);
        UpdatePieces(new string[] { "f", "r", "b", "l" });
        temp.GetComponent<Game2>().RightSwipe();
        temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Up), false);
        temp.GetComponent<Game2>().oneSideRotate(temp.GetComponent<Game2>().Side(temp.GetComponent<Game2>().Down), true);
    }
}
