using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float playerZ;

    private Vector3 offset;


    private void Update()
    {
        float playerZ = GameObject.Find("Player").transform.position.z - 4;
        float Enemy = transform.position.z;

        if (playerZ > Enemy)
        {
            PlayerController pCon = GameObject.Find("Player").GetComponent<PlayerController>();
            pCon.point = pCon.point + 1;
            pCon.pontUI.GetComponent<UnityEngine.UI.Text>().text = pCon.point.ToString();

            Destroy(this.gameObject);
        }

    }
}
