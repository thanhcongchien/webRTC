using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        // pos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        player.transform.position += input * speed * Time.deltaTime;
    }

    public void MovePlayer()
    {
        
    }
}
