using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBreak : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Brock001" || collision.gameObject.tag == "Brock002")
        {
            Destroy(collision.gameObject); // ���������I�u�W�F�N�g��j������
        }
    }
}
