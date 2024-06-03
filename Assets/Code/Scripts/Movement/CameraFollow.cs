using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow sharedInstance;

    [SerializeField] private float lerpTime;
    [SerializeField] private Transform currentTarget;
    public bool instantFollow;
    
    private float camOffsetX, camOffsetY, camOffsetZ;
    private float targetOffsetY;

    private void Awake() {
        if(sharedInstance == null){
            sharedInstance = this;
        }
    }

    void Start()
    {
        Transform camera = Camera.main.transform;
        camOffsetX = Mathf.Abs(currentTarget.transform.position.x) - Mathf.Abs(camera.position.x);
        camOffsetY = camera.position.y;
        camOffsetZ = Mathf.Abs(currentTarget.transform.position.z) - Mathf.Abs(camera.position.z);

        targetOffsetY = currentTarget.transform.position.y;
    }

    void LateUpdate()
    {
        Vector3 cameraOffset = new Vector3(currentTarget.transform.position.x + camOffsetX, currentTarget.transform.position.y + camOffsetY - targetOffsetY, currentTarget.transform.position.z + camOffsetZ);
        transform.position = Vector3.Lerp(transform.position, cameraOffset, lerpTime * Time.deltaTime);

        if(instantFollow){
            transform.position = cameraOffset;
        }
    }

    public void ChangeTarget(Transform target){
        currentTarget = target;
    }

    public IEnumerator InstantFollow(float time){
        CameraFollow.sharedInstance.instantFollow = true;
        yield return new WaitForSeconds(time);
        CameraFollow.sharedInstance.instantFollow = false;
    } 
}
