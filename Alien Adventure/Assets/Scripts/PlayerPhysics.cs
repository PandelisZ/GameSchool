using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour {

	public LayerMask collisionMask;

	private BoxCollider collider;
	private Vector3 s;
	private Vector3 c;

	private float skin = .005f;

	[HideInInspector]
	public bool grounded;
	[HideInInspector]
	public bool moveStop;

	Ray ray;
	RaycastHit hit;

	void Start () {
		collider = GetComponent<BoxCollider>();
		s = collider.size;
		c = collider.center;
	}

	public void Move (Vector2 moveAmount){

		float deltaY = moveAmount.y;
		float deltaX = moveAmount.x;
		Vector2 p = transform.position;


		//Check collisions above
		grounded = false;

		for (int i = 0; i < 3; i++) {
			float dir = Mathf.Sign(deltaY);
			float x = (p.x + c.x -s.x/2) + s.x/2 * i;
			float y = p.y + c.y + s.y/2 * dir;

			ray = new Ray(new Vector2(x,y), new Vector2(0,dir));

			if (Physics.Raycast (ray,out hit,Mathf.Abs(deltaY) + skin, collisionMask)){
				float dst = Vector3.Distance (ray.origin, hit.point);

				if (dst > skin){
					deltaY = -dst - skin * dir;
				}
				else {
					deltaY = 0;
				}
				grounded = true;
				break;
			}
		}

		//Check left and right
		moveStop = false;
		for (int i = 0; i < 3; i++) {
			float dir = Mathf.Sign(deltaX);
			float x = p.x + c.x + s.x/2 * dir;
			float y = p.y + c.y - s.y/2 + s.y/2 * i;
			
			ray = new Ray(new Vector2(x,y), new Vector2(dir,0));
			Debug.DrawRay (ray.origin, ray.direction);
			
			if (Physics.Raycast (ray,out hit,Mathf.Abs(deltaX) + skin, collisionMask)){
				float dst = Vector3.Distance (ray.origin, hit.point);
				
				if (dst > skin){
					deltaX = -dst - skin * dir;
				}
				else {
					deltaX = 0;
				}
				moveStop = true;
				break;
			}
		}

		Vector2 finalTransform = new Vector2(deltaX, deltaY);

		transform.Translate(finalTransform);
	}

}
