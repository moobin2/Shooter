using UnityEngine;
using System.Collections;

public class TitleCharacterMove : MonoBehaviour
{
    private float Speed;
    private Vector3 StartPosition;
    private Vector3 StartDirection;
    private int IsRight;

	// Use this for initialization
	void Start ()
    {
        StartPosition = Vector3.zero;
        StartDirection = Vector3.zero;
        ResetPostion();
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position += transform.forward * Speed;

        if(transform.position.z < -13)
        {
            ResetPostion();
        }
        else if (IsRight == 0 && transform.position.x <= -15)
        {
            ResetPostion();
        }
        else if (IsRight == 1 && transform.position.x >= 15)
        {
            ResetPostion();
        }
	}

    void ResetPostion()
    {
        IsRight = Random.Range(0, 2);

        if(IsRight == 0)
        {
            StartPosition.x = 15;
            transform.rotation = Quaternion.Euler(0, Random.Range(250, 269), 0);
        }
        else
        {
            StartPosition.x = -15;
            transform.rotation = Quaternion.Euler(0, Random.Range(91, 100), 0);
        }
        // 처음 시작위치
        StartPosition.y = Random.Range(-5, 5);
        StartPosition.z = -1;
        transform.position = StartPosition;

        // 처음 움직일 방향벡터
        StartDirection.x = Random.Range(1, 10);
        StartDirection.z = Random.Range(1, 10);
        StartDirection.Normalize();

        // 스피드 설정
        Speed = Random.Range(0.04f, 0.08f);
    }
}
