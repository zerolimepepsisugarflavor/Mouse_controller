using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    bool isFire; // �Ѿ��� �߻�Ǵ���
    Vector3 direction; //�Ѿ��� ���ư��� ����
    [SerializeField]
    float speed = 1f; //�Ѿ��� ���ư��� �ӵ�

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
    
    public void Fire(Vector3 dir) // �Ű������� dir�� �޾Ƽ� ���� ����
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
