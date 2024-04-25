using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHareketi : MonoBehaviour
{
    Vector3 yon;
    public float hiz;
    public ZeminSpawner zeminspawnerscripti;
    public static bool dustuMu;
    public float eklenecekHiz;
    // Start is called before the first frame update
    void Start()
    {
        yon = Vector3.forward;
        dustuMu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 0.5f)
        {
            dustuMu = true;
        }
        if(dustuMu == true)
        {
            Debug.Log("düştüm!");
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(yon.x == 0)
            {
                yon = Vector3.left;
            }
            else
            {
                yon = Vector3.forward;
            }
            hiz += eklenecekHiz * Time.deltaTime;
        }
        
    }
    private void FixedUpdate()
    {
        Vector3 hareket = yon*Time.deltaTime*hiz;
        transform.position += hareket;
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "zemin")
        {
            Score.score ++;
            collision.gameObject.AddComponent<Rigidbody>();
            zeminspawnerscripti.zemin_olustur();
            StartCoroutine(ZeminiSil(collision.gameObject));
        }
    }

    IEnumerator ZeminiSil(GameObject SilinecekZemin)
    {
        yield return new WaitForSeconds(3f);
        Destroy(SilinecekZemin);
    }
}
