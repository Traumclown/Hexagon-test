using UnityEngine;

public class GameField : MonoBehaviour
{
    public Field fieldPrefab;
    public enum FieldType { start, end, path, plain }


    public static Field[,] gameField;
    void Awake()
    {
        gameField = InitField(5, 5);
        MakePath(gameField);
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


    void MakePath(Field[,] field)
    {
        Field start = GetStartField();
        Field end = GetEndField();

        int x = start.x,
            y = start.y;

        while (true)
        {
            if (field[x, y].type != FieldType.start && field[x, y].type != FieldType.end)
                field[x, y].type = FieldType.path;

            if (x < end.x)
                x++;
            else if (x > end.x)
                x--;
            else
            {
                if (y < end.y)
                    y++;
                else if (y > end.y)
                    y--;
            }

            if (x == end.x && y == end.y)
                break;
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
            if (f.type == FieldType.path)
            {
                path[counter] = f;
                counter++;
            }

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