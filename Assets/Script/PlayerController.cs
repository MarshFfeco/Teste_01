using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    public GameObject cameraMov;
    private GameObject gmUI;
    public GameObject pontUI;

    public float speed = 10f;
    private float moveX;

    private Vector3 offset;

    private bool gm;
    public bool canJump = true;

    public int point;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        gmUI = GameObject.Find("Canvas");
        pontUI = GameObject.Find("Canvas2").transform.Find("Text").gameObject;

        gmUI.SetActive(false);
        gm = false;

        offset = cameraMov.transform.position - transform.position;

    }

    void FixedUpdate()
    {
        if (gm == false)
        {

            rb.AddForce(speed * Vector3.forward);

            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(speed * Vector3.left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(speed * Vector3.right);
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("SampleScene");
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                cameraMov.transform.Rotate(0, -1f, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                cameraMov.transform.Rotate(0, 1, 0);
            }
            if (canJump && Input.GetKey(KeyCode.Space))
            {
                rb.velocity = new Vector3(0, 10, 0);
                canJump = false;
            }

        } else if(gm == true)
        {
            Time.timeScale = 0;
            Time.timeScale = 1;

        }

        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("SampleScene");
        }

    }

    private void LateUpdate()
    {
        cameraMov.transform.position = transform.position + offset;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gmUI.SetActive(true);
            gm = true;
        }

        if(other.gameObject.tag == "Floor")
        {
            canJump= true;
        }
    }
}
