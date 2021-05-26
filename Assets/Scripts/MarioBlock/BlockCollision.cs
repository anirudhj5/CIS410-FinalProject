using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject block_done;
    public GameObject block_start;
    public GameObject Mushroom;
    public GameObject block_mushroom;
    Vector3 endPos;
    int count = 0;
    void Start()
    {
      rb = this.GetComponent<Rigidbody>();
      block_done.SetActive(false);
      block_mushroom.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
      if(count == 1)
      {
        Debug.Log("block");


        StartCoroutine(BlockMove());
      }
      count++;
    }


    IEnumerator BlockMove()
    {
        float timeElapsed = 0;
        endPos = (rb.transform.position + new Vector3 (0, 1f, 0));

        while (timeElapsed < .3f)
        {
            rb.transform.position = Vector3.Lerp(rb.transform.position, endPos, timeElapsed / .3f);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        rb.transform.position = endPos;
        timeElapsed = 0;
        endPos = (rb.transform.position + new Vector3 (0, -1.2f, 0));

        while (timeElapsed < .3f)
        {
            rb.transform.position = Vector3.Lerp(rb.transform.position, endPos, timeElapsed / .3f);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        rb.transform.position = endPos;
        timeElapsed = 0;
        endPos = (rb.transform.position + new Vector3 (0, .2f, 0));

        while (timeElapsed < .05f)
        {
            rb.transform.position = Vector3.Lerp(rb.transform.position, endPos, timeElapsed / .05f);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        block_start.SetActive(false);
        block_done.SetActive(true);


        rb.transform.position = endPos;


        rb = block_mushroom.GetComponent<Rigidbody>();
        timeElapsed = 0;
        endPos = (rb.transform.position + new Vector3 (0, 3.2f, 0));

        while (timeElapsed < 1f)
        {
            block_mushroom.SetActive(true);
            rb.transform.position = Vector3.Lerp(rb.transform.position, endPos, timeElapsed / 1f);
            timeElapsed += Time.deltaTime;
            yield return null;
            if(timeElapsed > .3f)
            {
              block_mushroom.SetActive(false);
              GameObject Mush = Instantiate(Mushroom) as GameObject;
              break;
            }
        }
      }




}
