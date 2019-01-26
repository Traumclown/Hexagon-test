using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    public Field fieldPrefab;
    public enum FieldType { start, end, path, plain }


    public static Field[,] gameField;
    void Awake()
    {
        gameField = InitField(5, 5);
    }

    Field[,] InitField(int width, int length)
    {
        Field[,] field = new Field[width, length];
        for (int y = 0; y < length; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float pos_x = x * 1.8f - (y % 2 == 0 ? 0.9f : 0);
                float pos_y = y * 1.6f;
                field[x, y] = Instantiate(fieldPrefab, new Vector3(pos_x, 2, pos_y), fieldPrefab.transform.rotation);
            }
        }
        fieldPrefab.GetComponent<Renderer>().enabled = false;
        int randx = Random.Range(0, width);
        int randy = Random.Range(0, length);
        Debug.Log("start " + randx + ", " + 0);
        Debug.Log("end " + 0 + ", " + randy);
        field[randx, 0].type = FieldType.start;
        field[0, randy].type = FieldType.end;
        //MakePath(field);
        return field;
    }


    void MakePath(Field[,] field) // TODO
    {
        //Field start = GetStartField(field);
        //Field end = GetEndField(field);
        int endX, endY, startX, startY;
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int p = 0; p < field.GetLength(1); p++)
            {
                if (field[i, p].type == FieldType.start)
                {
                    startX = i;
                    startY = p;
                    Debug.Log("start " + i + ", " + p);
                }
                else if (field[i, p].type == FieldType.end)
                {
                    endX = i;
                    endY = p;
                    Debug.Log("end " + i + ", " + p);
                }
            }
        }
    }

    public static Field GetEndField()
    {
        foreach (Field f in gameField)
            if (f.type == FieldType.end)
                return f;
        return null;
    }
    public static Field GetStartField()
    {
        foreach (Field f in gameField)
            if (f.type == FieldType.start)
                return f;
        return null;
    }
    public static Field[] GetPathFields()
    {
        int pathCount = 0;
        foreach (Field f in gameField)
            if (f.type == FieldType.path)
                pathCount++;

        Field[] path = new Field[pathCount];
        int counter = 0;
        foreach (Field f in gameField)
            if (f.type == FieldType.path)// TODO counter
                path[counter] = f;

        return path;
    }
    public static Transform[] GetPathFieldsAsTransform()
    {
        Field[] path = GetPathFields();
        Transform[] pathAsTransform = new Transform[path.Length];
        int counter = 0;
        foreach (Field f in path)
        {
            pathAsTransform[counter] = f.transform;
            counter++;
        }

        return pathAsTransform;
    }
}