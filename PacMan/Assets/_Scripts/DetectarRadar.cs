using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarRadar : MonoBehaviour
{
    public bool radar;
    public float rango = 5f;
    public LayerMask mask;

    private void Update()
    {
        radar = Physics.CheckSphere(transform.position, rango, mask);
        if (radar) gameObject.GetComponent<MeshRenderer>().enabled = true;
        else gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
