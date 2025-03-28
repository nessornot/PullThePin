using UnityEngine;

public class ColoringBalls : MonoBehaviour
{
    bool iscolored;
    public GameObject particle;
    public Material[] materialsBall;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "colorball")
        {
            if (!iscolored)
            {
                if (GameManager.instant.getSound() == 1)
                {
                    SoundManager.instance.Play("detect");
                }

                int rdm = Random.Range(0 , materialsBall.Length);
                GetComponent<MeshRenderer>().material = materialsBall[rdm];
                ParticleSystem.MainModule settings = particle.GetComponent<ParticleSystem>().main;
                settings.startColor = new ParticleSystem.MinMaxGradient(materialsBall[rdm].color);
                Vector3 tmp = transform.position;
                tmp.z -=.3f;
                Destroy(Instantiate(particle , tmp , particle.transform.rotation) , 5f);
                transform.gameObject.tag = "colorball";
                iscolored = true;
                print("colored");
            }
                
        }
    }
    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "colorball")
        {
            if(!iscolored)
            {
                if (GameManager.instant.getSound() == 1)
                {
                    SoundManager.instance.Play("detect");
                }
                
                int rdm = Random.Range(0 , materialsBall.Length);
                GetComponent<MeshRenderer>().material = materialsBall[rdm];
                ParticleSystem.MainModule settings = particle.GetComponent<ParticleSystem>().main;
                settings.startColor = new ParticleSystem.MinMaxGradient(materialsBall[rdm].color);
                Vector3 tmp = transform.position;
                tmp.z -=.3f;
                Destroy(Instantiate(particle , tmp , particle.transform.rotation) , 5f);
                transform.gameObject.tag = "colorball";
                iscolored = true;
                print("colored");
            }
                
        }
    }
}
