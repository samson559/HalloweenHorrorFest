using UnityEngine;
using System.Collections;

public class ProjectileBehavior : MonoBehaviour
{
    public Vector2 InitialVelocity = new Vector2(1, 1);
    public float ExplodeTime = 1f;
    public GameObject Explosion;

    private float ExplodeTimer_;
    private bool hasCollided = false;
    [SerializeField]private float explosionRad;

    Rigidbody2D body;
    // Use this for initialization
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        ExplodeTimer_ = ExplodeTime;
    }

    // Update is called once per frame
    void Update()
    {
        ExplodeTimer_ -= Time.deltaTime;

        if (ExplodeTimer_ <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            if (!hasCollided)
            {
                hasCollided = true;
                ExplodeTimer_ = .25f;
            }
        }
    }
    private void explod()
    {
        GameObject.Destroy(GameObject.Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject, .5f);
        Collider2D hit = Physics2D.OverlapCircle(transform.position, explosionRad);
        if(hit.gameObject.CompareTag("Player"))
        {
            Vector2 dir = new Vector2(hit.gameObject.transform.position.x - transform.position.x, hit.gameObject.transform.position.y - transform.position.y);
           hit.gameObject.SendMessage("takeDamage",dir.normalized);
        }
        else
        {

        }
    }

}
