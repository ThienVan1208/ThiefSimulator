using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanTakeObj : MonoBehaviour
{
    // Start is called before the first frame update
    public float take_time;
    public GameObject player;
    private bool canTake, taking_time;
    public GameObject key;
    private Coroutine curCo;
    private MainControl main_control;
    void Start()
    {
        main_control = player.GetComponent<MainControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canTake && curCo == null)
        {
            Key();
        }
        else
        {
            key.SetActive(false);
        }
        if (key.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E) && curCo == null)
            {
                curCo = StartCoroutine(StartTaking());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canTake = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canTake = false;
        }
    }
    void Key()
    {
        key.SetActive(true);
    }
    IEnumerator StartTaking()
    {
        main_control.TakeObject();
        canTake = false;
        key.SetActive(false);
        taking_time = true;
        yield return new WaitForSeconds(take_time);
        main_control.StopTaking();
        curCo = null;
        taking_time = false;
        main_control.canvasForTakeObj.SetActive(false);
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        if(taking_time)
        {
            main_control.TakeSliderEffect(take_time);
        }
    }
}
