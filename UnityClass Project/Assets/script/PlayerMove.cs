using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float DashSpeed;
    private bool Check;
    private int Rap;
    private Text textRap;
    public GameObject GoalText;

    // Start is called before the first frame update
    void Start()
    {
        DashSpeed = 100;
        Check = false;
        Rap = 0;
        textRap = GameObject.Find("Rap").GetComponent<Text>();
        SetRapText(Rap);
        //GoalText.SetActive(false);
    }

    private void SetRapText(int Rap)
    {
        textRap.text = "Rap:" + Rap.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position -= transform.TransformDirection(Vector3.forward * DashSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0));
        }
        if (Rap == 3)
        {
            //GoalText.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MidPoint")
        {
            Check = true;
        }
        if (other.gameObject.tag == "Start" && Check == true)
        {
            Rap += 1;
            Check = false;
        }
    }
}
