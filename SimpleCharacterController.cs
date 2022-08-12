using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    Camera characterCamera;
    GameObject Character;

    public GameObject bulletPrefab;

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 firePos = transform.position + animator.transform.forward + new Vector3(0f, 0.5f, 0f);
            var bullet = Instantiate(bulletPrefab, firePos, Quaternion.identity).GetComponent<bullet>();
            bullet.Fire(animator.transform.forward);
        }
        //else if (Input.GetMouseButton(0)) 꾹 눌렀을 때
        //{
        //    Vector3 firePos = transform.position + animator.transform.forward + new Vector3(0f, 0.5f, 0f);
        //    var bullet = Instantiate(bulletPrefab, firePos, Quaternion.identity).GetComponent<bullet>();
        //    bullet.Fire(animator.transform.forward);
            
        //}
    }

    private void Awake()
    {
        characterCamera = GetComponentInChildren<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
      
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(moveX, 0f, moveZ);
        // 무브 벡터의 길이가 0이 아니면 키 입력이 들어오는 것으로 판정
        bool isMove = moveVector.magnitude > 0;
        // 애니메이터의 isMove의 값을 무브 벡터의 길이에 따라서 바뀌도록 함
        animator.SetBool("isMove", isMove);
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
        }

        LookMouseCursor();
        Fire();
        
        Zoom();

   
        // 유니티 엔진 1 단위는 1미터
        transform.Translate(new Vector3(moveX, 0f, moveZ).normalized * Time.deltaTime * 5f);
    }

    public void LookMouseCursor()
    {
        Ray ray = characterCamera.ScreenPointToRay(Input.mousePosition); //Ray 클래스를 이용한 카메라에서 광선 쏘기.
        RaycastHit hitResult;

            if(Physics.Raycast(ray, out hitResult))
        {
            Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
            animator.transform.forward = mouseDir;
            //광선이 맞은 물체의 정보 - 캐릭터의 위치를 빼면 캐릭터에서 마우스로 향하는 방향을 구할 수 있다. 
            // 광선이 맞은 위치의 y좌표를 캐릭터의 y좌표로 변경해야함. 그렇지 않으면 캐릭터보다 높거나 낮은 위치를 광선이 맞았을 때
            // 캐릭터가 기울어 질 수 있음.
        }


        //스크린 스페이스의 좌표 .월드 스페이스로 변경해야하는데 이 기능을 Camera 클래스가 가지고 있다.

    }

    private void Zoom()
    {
        var scroll = Input.mouseScrollDelta;// 스크롤 입력 가져옴.
        characterCamera.fieldOfView = Mathf.Clamp(characterCamera.fieldOfView - scroll.y , 30f, 70f); 
        // 방어 코딩 , 문제가 미리 발생할 것 같은 부분은 예상해서 미리 코딩하는것.
    }
}
