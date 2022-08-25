using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;

    public Transform sPoint;
    public float timeBetweenShots = 1f;

    private float shotTime;


    [SerializeField]
    Transform p_tran;


    // Start is called before the first frame update
    void Start()
    {
        p_tran = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (p_tran == null)
        {
            p_tran = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.gameStart)
        {
            return;
        }



        Vector2 direction = p_tran.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        if(Time.time >= shotTime)
        {
            Instantiate(bullet, sPoint.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
            shotTime = Time.time + timeBetweenShots;
        }
    }

    //출처 https://mentum.tistory.com/227
}
