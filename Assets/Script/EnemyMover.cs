using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]//it will automatically include Enemy Script along with this and also not include it twice
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField][Range(0f, 5f)] float Speed = 1f;

    [SerializeField] string taged = "Path";
    Enemy enemy;
    void Awake()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());

    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag(taged);

        foreach (Transform child in parent.transform)
        {
            WayPoint waypoint = child.GetComponent<WayPoint>();

            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        this.gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach (WayPoint waypoint in path)
        {
            Vector3 startPosition = this.transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            float rotationDegrees = degreesToRotate(this.transform.forward, startPosition, endPosition);

            while (travelPercent < 1f)
            {
                if (travelPercent < 0.25f)
                {
                    float rotationAngle = 4 * rotationDegrees * Time.deltaTime * Speed;
                    this.transform.Rotate(new Vector3(0, rotationAngle, 0));
                }

                travelPercent += Time.deltaTime * Speed;
                transform.position = Vector3.Lerp(
                    startPosition,
                    endPosition,
                    travelPercent
                );
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();

    }
    float degreesToRotate(Vector3 currentDir, Vector3 currentPosition, Vector3 endPosition)
    {
        Vector3 targetDir = endPosition - currentPosition;
        return Vector3.SignedAngle(currentDir, targetDir, Vector3.up);
    }

}
