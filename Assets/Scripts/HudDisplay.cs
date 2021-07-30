using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HudDisplay : MonoBehaviour
{

    [SerializeField] private Text InputText; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void OnSpawnBallsClicked()
    {
        int nSpawns;

        int.TryParse(InputText.text, out nSpawns);

        if (nSpawns == 0)
        {
            nSpawns = 1;
        }

        Parameters parameters = new Parameters();
        parameters.PutExtra(SpawnSystem.NUM_SPAWNS_KEY, nSpawns);

        EventBroadcaster.Instance.PostEvent(EventNames.ON_SPAWN_BALL_BUTTON_CLICKED, parameters);
    }

    public void OnSpawnCubeClicked()
    {
        int nSpawns;
        int.TryParse(InputText.text, out nSpawns);

        if (nSpawns == 0)
        {
            nSpawns = 1;
        }

        Parameters parameters = new Parameters();
        parameters.PutExtra(SpawnSystem.NUM_SPAWNS_KEY, nSpawns);

        EventBroadcaster.Instance.PostEvent(EventNames.ON_SPAWN_CUBE_BUTTON_CLICKED, parameters);
    }

    public void OnClearButtonClicked()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.ON_CLEAR_BUTTON_CLICKED);
    }

        public void OnRandomizeColorbuttonClicked()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.ON_RANDOMIZE_COLOR_BUTTON_CLICKED);
    }

}
