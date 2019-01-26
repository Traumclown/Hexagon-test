using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    public Field fieldPrefab;
    public enum FieldType { start, end, path, plain }

    private static Field[,] gameField;
    private static Field[] path;
    void Awake()
    {
        gameField = InitField(5, 5);
        path = MakePath(gameField);
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
                field[x, y].x = x;
                field[x, y].y = y;
            }
        }
        fieldPrefab.GetComponent<Renderer>().enabled = false;

        int randStart = Random.Range(0, width);
        int randEnd = Random.Range(0, width);
        field[randStart, 0].type = FieldType.start;
        field[randEnd, length - 1].type = FieldType.end;

        return field;
    }

    Field[] MakePath(Field[,] field)
    {
        Field start = GetStartField();
        Field end = GetEndField();

        int x = start.x,
            y = start.y;

        List<Field> path = new List<Field>();

        while (!(x == end.x && y == end.y))
        {
            if (x < end.x)
                x++;
            if (x > end.x)
                x--;
            if (y < end.y)
                y++;
            if (y > end.y)
                y--;

            if (field[x, y].type != FieldType.start && field[x, y].type != FieldType.end)
            {
                field[x, y].type = FieldType.path;
                path.Add(field[x, y]);
            }
        }

        return path.ToArray();
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
        return path;
    }

    public static Transform[] GetPathFieldsAsTransform()
    {
        Field[] path = GetPathFields();
        Transform[] pathAsTransform = new Transform[path.Length];
        for (int i = 0; i < path.Length; i++)
        {
            pathAsTransform[i] = path[i].transform;
        }

        return pathAsTransform;
    }
}