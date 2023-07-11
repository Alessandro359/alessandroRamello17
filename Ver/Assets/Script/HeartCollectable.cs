using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollectable : MonoBehaviour
{
    [SerializeField] private float value;
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player"){
            collision.GetComponent<Health>().AddHealt(value);
            gameObject.SetActive(false);
        }
    }
}
