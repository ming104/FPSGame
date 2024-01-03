using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float turnSpeed = 4.0f; // 마우스 감도    
    private float xRotate = 0.0f;

    public float moveSpeed = 4.0f; // 기본속도
    public float jumpForce = 10.0f; // 점프강도
    public float RunSpeed; // 달리기 속도
    public static bool isGround = true; // 땅에 붙어있는가?
    public static bool isRun = false; // 달리고 있는가?
    public GameObject HpPanel; // 피해를 받았을 때 나오는 창
    Rigidbody body; // Rigidbody중력
    public GameObject bullet; // 총알 오브젝트
    public Transform bulletpos; // 총알을 쏘는 죄표
    public static int Tangchag; // 탄창
    public bool isShot; // 총을 쏘고 있는가?
    public bool isReload;// 재장전중인가?
    public AudioSource ShotSound; // 총발사 사운드
    public AudioSource ReloadSound; // 재장전 사운드
    public GameObject RReload; 
    public static int Killcount; // 킬 카운트
    public GameObject Gun; // 총
    public GameObject Knifego; // 칼
    public static bool gunon; // 총을 들고 있는가?
    public AudioSource KnifeSound; // 칼로 찌를때
    public GameObject BoxKnife; // 칼
    public Animator anim;


    void Start()
    {
        Time.timeScale = 1;
        //knifeAni = GetComponent<Animator>();        // Animator받기
        body = GetComponent<Rigidbody>();           // Rigidbody중력값 받기
        transform.rotation = Quaternion.identity;   // 쿼터니언으로 각도 받기
        HpPanel.SetActive(false);
        Tangchag = 30;
        isShot = false;
        RReload.SetActive(false);
        Knifego.SetActive(false);
        Killcount = 0;
        gunon = true;
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isReload == false && isShot == false && gunon == true) // 총쏘기
        {
            if (Tangchag > 0)
            {
                Instantiate(bullet, bulletpos.transform.position, bulletpos.transform.rotation);
                ShotSound.Play();
                Tangchag--;
                isShot = true;
                Invoke("Tang", 0.5f);
            }
        }
        if(Input.GetKeyDown(KeyCode.R) && isShot == false && isReload == false && gunon == true) // 재장전 키를 눌렀는가?, 안쏘고 있는가, 재장전 중인가?, 총이 켜져있는가?
        {
            isReload = true;
            ReloadSound.Play();
            Invoke("Reload", 3.5f);
        }
        if(Tangchag == 0 && gunon == true)
        {
            RReload.SetActive(true);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Gun.SetActive(false);
            Knifego.SetActive(true);
            gunon = false;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Gun.SetActive(true);
            Knifego.SetActive(false);
            gunon = true;
        }
        if (Input.GetMouseButtonDown(0) && gunon == false)
        {
            BoxKnife.SetActive(true);
            KnifeSound.Play();
            anim.SetBool("Hit", true);
            Invoke("KnifeA", 0.15f);
        }
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        // X로 돌리기
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // y로 돌리기
        float yRotate = transform.eulerAngles.y + yRotateSize;
        // y축으로 돌리기
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // y축으로 돌리기
        // Clamp 는 각도를 고정하는 함수
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

        //  이동
        Vector3 move = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");

        // 달리기
        transform.position += move * moveSpeed * Time.deltaTime;

        // isRun 초기화
        if(Input.GetKey(KeyCode.W) && isRun == true && !Input.GetKey(KeyCode.LeftShift))
        {
            isRun = false;
        }
        if (Input.GetKey(KeyCode.A) && isRun == true && !Input.GetKey(KeyCode.LeftShift))
        {
            isRun = false;
        }
        if (Input.GetKey(KeyCode.S) && isRun == true && !Input.GetKey(KeyCode.LeftShift))
        {
            isRun = false;
        }
        if (Input.GetKey(KeyCode.D) && isRun == true && !Input.GetKey(KeyCode.LeftShift))
        {
            isRun = false;
        }

        // 달리기 게이지
        if (EnergyBar.currentEnergy < 100)
        {
            if (Input.GetKey(KeyCode.LeftShift) && isGround == true)
            {
                transform.position += move * moveSpeed * RunSpeed * Time.deltaTime;
                isRun = true;
            }
        }
    }

    void Jump() // 점프
    {
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isGround = false;
        }
    }

    // ~에 닿았는가 (땅에 닿았는가), (적에게 닿았는가)
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HPbar.currenthp += 10;
            gameObject.tag = "Nodie";
            HpPanel.SetActive(true);
            Invoke("HpPanelOff", 1f);
            Invoke("Muzek", 3f);
        }
    }

    void Muzek() //무적시간
    {
        gameObject.tag = "Player";
    }

    void HpPanelOff() // 피해를 입었을때 나오는 판넬 끄는 함수
    {
        HpPanel.SetActive(false);
    }

    void Reload() // 재장전
    {
        Tangchag = 30;
        RReload.SetActive(false);
        isReload = false;
    }

    void Tang() // 총쏘기 끝났을때
    {
        isShot = false;
    }

    void KnifeA()
    {
        anim.SetBool("Hit", false);
        BoxKnife.SetActive(false);
    }

}