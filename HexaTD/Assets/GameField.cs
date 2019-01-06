using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{

    public Transform field;

    void Start()
    {
        InitField(5, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitField(int width, int length)
    {
        for (int y = 0; y < length; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float pos_x = x * 1.8f - (y % 2 == 0 ? 0.9f : 0);
                float pos_y = y * 1.6f;
                Instantiate(field, new Vector3(pos_x, 2, pos_y), field.rotation);
            }
        }
        field.GetComponent<Renderer>().enabled = false;
    }
}