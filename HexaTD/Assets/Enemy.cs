using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform[] path;

    void Start()
    {
        path = GameField.GetPathFieldsAsTransform();
        gameObject.transform.position = GameField.GetStartField().transform.position;
        target = path[0];
    }

    private int pathIndex = 0;
    private Transform target;
    void Update()
    {
        float speed = 2f;
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.01f)
        {
            if (pathIndex < path.Length - 1)
            {
                pathIndex++;
                target = path[pathIndex];
            }
            else
            {
                if(target == GameField.GetEndField().transform)
                    Destroy(gameObject);

                target = GameField.GetEndField().transform;
            }
        }
    }
}
