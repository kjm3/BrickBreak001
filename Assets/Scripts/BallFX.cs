using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFX : MonoBehaviour
{
    public GameObject pt;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brock001" || collision.gameObject.tag == "Brock002")
        {
            Instantiate(pt, this.transform.position, Quaternion.identity);
        }
    }
}
