using System.Collections;
using UnityEngine;

public class lucky : MonoBehaviour
{

    public GameObject blox;
    public GameObject breakEffect;
    public Animator anim;
    private bool NOOW = false;
    private bool chill = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim.SetTrigger("idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (NOOW && !chill)
        {
            anim.SetTrigger("breaker");
            StartCoroutine(hap());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NOOW = true;
        }
    }

    IEnumerator hap()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(breakEffect, blox.transform.position, blox.transform.rotation);
        Destroy(blox);
        chill = true;
    }
}
