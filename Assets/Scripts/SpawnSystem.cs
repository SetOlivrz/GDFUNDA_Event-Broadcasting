using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject template;
    [SerializeField] private List<GameObject> spawnList;
    [SerializeField] private List<GameObject> spawnListSphere;


    public const string NUM_SPAWNS_KEY = "NUM_SPAWNS_KEY";

    // Start is called before the first frame update
    void Start()
    {
        this.template.SetActive(false);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_SPAWN_CUBE_BUTTON_CLICKED, this.OnSpawnEvent);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_SPAWN_BALL_BUTTON_CLICKED, this.OnSpawnSphereEvent);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_CLEAR_BUTTON_CLICKED, this.OnClearEvent);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_RANDOMIZE_COLOR_BUTTON_CLICKED, this.OnRandomizeColorEvent);
    }


    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_SPAWN_CUBE_BUTTON_CLICKED);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_SPAWN_BALL_BUTTON_CLICKED);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_CLEAR_BUTTON_CLICKED);

        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_RANDOMIZE_COLOR_BUTTON_CLICKED);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSpawnEvent(Parameters parameters)
    {
        int nSpawns = parameters.GetIntExtra(NUM_SPAWNS_KEY, 1);

        for (int i=0; i<nSpawns; i++)
        {
            GameObject copy = GameObject.Instantiate(template, this.transform);
            copy.SetActive(true);
            spawnList.Add(copy);
        }
    }

    void OnSpawnSphereEvent(Parameters parameters)
    {
        int nSphereSpawns = parameters.GetIntExtra(NUM_SPAWNS_KEY, 1);
        //int nSpawn = 5;

        for (int i = 0; i < nSphereSpawns; i++)
        {
            //Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), new Vector3(-5, 15, -5), Quaternion.identity, null);
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.AddComponent(typeof(Rigidbody));
            sphere.transform.position = new Vector3(0, 2, 0);
            spawnList.Add(sphere);

        }


    }
    public void OnClearEvent()
    {
        if (spawnList.Count > 0)
        {
            for (int i = 0; i < spawnList.Count; i++)
            {
                Destroy(spawnList[i]);
            }
            this.spawnList.Clear();
        }
        else
        {
            Debug.Log("Empty Spawn List");
        }
    }

    public void OnRandomizeColorEvent()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {

            float r = Random.Range(0.0f, 1.0f);
            float g = Random.Range(0.0f, 1.0f);
            float b = Random.Range(0.0f, 1.0f);

            Color color = new Color(r, g, b);

            spawnList[i].gameObject.GetComponent<MeshRenderer>().material.color = color;
        }

        for (int i = 0; i < spawnList.Count; i++)
        {

            float r = Random.Range(0.0f, 1.0f);
            float g = Random.Range(0.0f, 1.0f);
            float b = Random.Range(0.0f, 1.0f);

            Color color = new Color(r, g, b);

            spawnList[i].gameObject.GetComponent<MeshRenderer>().material.color = color;
        }
    }
}
