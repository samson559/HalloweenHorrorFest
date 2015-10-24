using UnityEngine;
using System.Collections;

public class ProjectileBehavior: MonoBehaviour {
    public Vector2 InitialVelocity = new Vector2(1,1);
    public float ExplodeTime = 1f;
    public GameObject Explosion;

    private float ExplodeTimer_;

    Rigidbody2D body;
    // Use this for initialization
	void Start () {
        body = gameObject.GetComponent<Rigidbody2D>();
        body.AddForce(InitialVelocity);
        ExplodeTimer_ = ExplodeTime;
	}
	
	// Update is called once per frame
	void Update () {
        ExplodeTimer_ -= Time.deltaTime;

        if (ExplodeTimer_ <= 0)
        {
            Destroy(this.gameObject);
            GameObject.Destroy(GameObject.Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject,.5f);
        }
	}
}
