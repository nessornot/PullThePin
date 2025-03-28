using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject controlegame;
    ControleGame controleScript;
    public GameObject particleExplosion;
    Animator anim;
    public Material material;
    public LayerMask layer;
    Rigidbody rb;
    bool isexplosion;
    bool isend;
    float speed = .12f;
    bool isInCollission;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        controleScript = controlegame.GetComponent<ControleGame>();
    }

    void Update()
    {
        print(rb.velocity.y);
        if(!isexplosion)
        {
            if(rb.velocity.y <= -3f || rb.velocity.x <= -.5f || rb.velocity.x >= .5f)            {
                StartCoroutine(animationExplosion());
                print("velocity");
            }
        }

        if(isexplosion && !isend && isInCollission)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position , 2f,layer);
            int nbrcolliders = colliders.Length;

            foreach (Collider col in colliders)
            {
                col.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Vector3 direction = new Vector3(Random.Range(-10f,10f),Random.Range(-10f,10f),Random.Range(-5f,-10f));
                col.GetComponent<Rigidbody>().AddForce(direction * speed , ForceMode.Impulse);
            }

            if (GameManager.instant.getSound() == 1)
            {
                SoundManager.instance.Play("boom");
            }
                
            Instantiate(particleExplosion , transform.position , particleExplosion.transform.rotation);
            if (nbrcolliders > 0)
            {
                controleScript.showpanelOutSideScript();
            }
                
            print("nbrcollider "+nbrcolliders);
            isend = true;
            Destroy(gameObject);
        }
        else if(isexplosion && !isend)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position , 2f,layer);
            int nbrcolliders = colliders.Length;

            foreach (Collider col in colliders)
            {
                Vector3 direction = new Vector3(Random.Range(-15f,15f),Random.Range(-15f,15f),0f);
                col.GetComponent<Rigidbody>().AddForce(direction * speed , ForceMode.Impulse);
            }

            if (GameManager.instant.getSound() == 1)
            {
                SoundManager.instance.Play("boom");
            }

            Instantiate(particleExplosion , transform.position , particleExplosion.transform.rotation);
            Destroy(gameObject);
            isend = true;
        }
    }

    IEnumerator animationExplosion()
    {
        transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = material;
        anim.SetBool("explosion",true);
        yield return new WaitForSeconds(2f);
        isexplosion = true;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "colorball" || other.gameObject.tag == "emptyball")
        {
            isInCollission = true;
            if (!isexplosion)
            {
                StartCoroutine(animationExplosion());
            }
        }
    }
}
