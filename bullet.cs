using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    bool isFire; // 총알이 발사되는지
    Vector3 direction; //총알이 날아가는 방향
    [SerializeField]
    float speed = 1f; //총알이 날아가는 속도

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isFire)
        {
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }
    
    public void Fire(Vector3 dir) // 매개변수로 dir을 받아서 방향 설정
    {
        direction = dir;
        isFire = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<bullet>() == null)
        {
            Destroy(gameObject);
        }
    }

    

}
