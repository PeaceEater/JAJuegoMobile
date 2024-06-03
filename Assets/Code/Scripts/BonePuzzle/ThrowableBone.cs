using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableBone : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private GameObject boneItemPrefab;
    private Rigidbody rb;

    public void Throw(){
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce(new Vector3(-1, 1, 0) * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Floor")){
            Vector3 prefabPos = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
            GameObject instance = Instantiate(boneItemPrefab, prefabPos, Quaternion.identity);
            instance.transform.parent = GameObject.Find("DynamicObjects").transform;
            Destroy(gameObject);
        }
    }
}
