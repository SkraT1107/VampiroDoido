using UnityEngine;

public class XPOrb : MonoBehaviour
{
    public int xpValue;
    public float speed;
    private Transform target;
    private float distance;
    public float raioDetect = 10;


    private void Start()
    {
        target = PlayerControler.Instance.transform;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerXP>().AddXP(xpValue);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(target != null)
        {
            Vector2 diferenca = target.position - transform.position;
            distance = diferenca.magnitude;
            if(distance <= raioDetect)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            } 
        }
    }
}
