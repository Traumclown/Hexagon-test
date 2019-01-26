using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform[] path;

    void Start()
    {
        path = GameField.GetPathFieldsAsTransform();
    }

    private int pathIndex = 0;
    void Update()
    {
        if (path == null) return;

        //Debug.Log("path.Length: " + path.Length);
        //Debug.Log("pathIndex: " + pathIndex);
        if (pathIndex >= path.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        Transform target = path[pathIndex];
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            target = path[pathIndex++];

        float speed = 10f;
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }
}
