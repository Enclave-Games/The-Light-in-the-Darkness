using UnityEngine;

public class FollowingCamera : MonoBehaviour
{

    [SerializeField]
    Transform target;
    [SerializeField]
	float smoothTime = 0.5F;
    [SerializeField]
    float offset=5f;

    Vector3 vectorOffset;
    bool hasController;
    Vector2 velocity = Vector3.zero;

	void Start(){
		if(target.GetComponent<PlayerController>() != null) hasController = true;
    }

    void Update () {
		vectorOffset = new Vector3(offset,0f);
        transform.position = 
			new Vector2(Vector2.SmoothDamp(transform.position
				, hasController ? getTarget() : (Vector2) target.position 
					, ref velocity, 1, 5, smoothTime).x, transform.position.y);
	}

	Vector2 getTarget(){
        return target.position + (target.GetComponent<PlayerController>().toRight
            ? vectorOffset : -vectorOffset);
    }
}
