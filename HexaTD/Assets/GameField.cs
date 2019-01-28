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
            for (int x = 0; x < width; x++)
            {
                bool even = y % 2 == 0;
                float pos_x = x * 1.8f - (even ? 0.9f : 0);
                float pos_y = y * 1.6f;
                field[x, y] = Instantiate(fieldPrefab, new Vector3(pos_x, 2, pos_y), fieldPrefab.transform.rotation);
                field[x, y].x = x;
                field[x, y].y = y;
            }
        fieldPrefab.GetComponent<Renderer>().enabled = false;

        for (int y = 0; y < length; y++)
            for (int x = 0; x < width; x++)
            {
                bool even = y % 2 == 0;
                Field[] neighbours = new Field[6];
                if (y - 1 >= 0)
                    neighbours[0] = field[x, y - 1];
                if (x - 1 >= 0)
                    neighbours[1] = field[x - 1, y];
                if (x + 1 < width)
                    neighbours[2] = field[x + 1, y];
                if (y + 1 < length)
                    neighbours[3] = field[x, y + 1];

                if (!even)
                {
                    if (x + 1 < width && y + 1 < length)
                        neighbours[4] = field[x + 1, y + 1];
                    if (x + 1 < width && y - 1 >= 0)
                        neighbours[5] = field[x + 1, y - 1];
                }
                else
                {
                    if (y - 1 >= 0 && x - 1 >= 0)
                        neighbours[4] = field[x - 1, y - 1];
                    if (x - 1 >= 0 && y + 1 < width)
                        neighbours[5] = field[x - 1, y + 1];
                }

                field[x, y].neighbours = neighbours;
            }

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
            if (x < end.x) // && field[x, y].neighbours
                x++;
            else if (x > end.x)
                x--;
            else if (y < end.y)
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