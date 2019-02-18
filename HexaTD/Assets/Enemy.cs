using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Field[] path;
    public Round round;

    void Start()
    {
        path = GameField.GetPathFields();
        gameObject.transform.position = GameField.GetStartField().transform.position;
        target = path[0].transform;
        round.OnRoundUpdate += OnRoundUpdate;
    }

    bool newRound = false;
    void OnRoundUpdate()
    {
        newRound = true;
    }
    public void OnMouseDown()
    {
        OnRoundUpdate();

    }
    private int pathIndex = 1;
    private Transform target;
    void Update()
    {
        if (target == null)
            throw new System.Exception("no target set");

        float speed = 2f;
        Vector3 dir = target.position - transform.position;


        if (Vector3.Distance(transform.position, target.position) <= 0.05f)
        {
            if (pathIndex < path.Length - 1)
            {
                if (newRound)
                {
                    newRound = false;
                    pathIndex++;
                    target = path[pathIndex].transform;
                }
            }
            else
            {
                if (target == GameField.GetEndField().transform)
                    Destroy(gameObject);

                target = GameField.GetEndField().transform;
            }
        }
        if (newRound)
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

    }
}
