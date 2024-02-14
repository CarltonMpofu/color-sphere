using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    OrbColorSO orbColorSO;
    
    [SerializeField] ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOrbColor(OrbColorSO newOrbColorSO)
    {
        orbColorSO = newOrbColorSO;

        gameObject.GetComponent<SpriteRenderer>().color = orbColorSO.GetColor();
    }

    public int GetOrbColorID()
    {
        return orbColorSO.GetColorID();
    }

    public void PlayParticle()
    {
        ParticleSystem newPs = Instantiate(ps, transform.position, Quaternion.identity);
        ParticleSystem.MainModule ma = newPs.main;
        ma.startColor = orbColorSO.GetColor();
        newPs.Play();
    }
}
