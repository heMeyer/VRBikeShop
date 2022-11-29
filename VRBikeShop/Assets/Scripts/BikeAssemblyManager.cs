using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BikeAssemblyManager : MonoBehaviour
{
    XRSocketInteractor xRSocketInteractor;
    public GameObject bicycleAssembly;
    private bool somethingInSocket = false;
    private bool wrenchInReach = false;
    public int partCount = 0;
    private ArrayList bikeParts = new ArrayList();

    private AudioSource audioSource;
    public AudioClip screwSound;

    // Start is called before the first frame update
    void Start()
    {
        xRSocketInteractor = GetComponent<XRSocketInteractor>();
        audioSource = this.transform.parent.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        socketCheck();

        if (somethingInSocket && partCount >= 13 && wrenchInReach)
        {
            StartCoroutine(assembleBike());
            partCount = 0;
        }
    }

    void socketCheck()
    {
        somethingInSocket = xRSocketInteractor.hasSelection;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Wrench_Open")
        {
            wrenchInReach = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Wrench_Open")
        {
            wrenchInReach = false;
        }
    }

    public void addInSocket(GameObject bikePart)
    {
        partCount++;
        bikeParts.Add(bikePart);
    }

    IEnumerator assembleBike()
    {
        mergeBike1();
        yield return new WaitForSeconds(screwSound.length);
        mergeBike2();
    }

    void mergeBike1()
    {
        Debug.Log("Rad zusammengebaut");

        audioSource.clip = screwSound;
        audioSource.Play();

        assembleBike();
    }

    void mergeBike2()
    {
        foreach (GameObject go in bikeParts)
        {
            Destroy(go);
        }

        bikeParts.Clear();

        bicycleAssembly.SetActive(true);
    }
}
