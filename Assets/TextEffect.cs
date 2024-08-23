using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public MainControl player;
    public TextMeshProUGUI text_effect;
    private Coroutine cur;
    private Vector2 getScale;
    void Start()
    {
        cur = null;
        getScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(cur == null)
        {
            cur = StartCoroutine(EffectText());
        }

        if(player.transform.localScale.x <= 0)
        {
            transform.localScale = new Vector2(-getScale.x, getScale.y);
        }
        else
        {
            transform.localScale = getScale;
        }

    }
    IEnumerator EffectText()
    {
        text_effect.text = "Taking";
        for(int i = 0; i < 3; i++)
        {
            text_effect.text += ".";
            yield return new WaitForSeconds(0.2f);
        }
        cur = null;
    }
}
