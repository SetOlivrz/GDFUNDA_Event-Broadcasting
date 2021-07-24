using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HudDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void OnSpawnButtonClicked()
    {
        int nSpawns = 5;
        Parameters parameters = new Parameters();
        parameters.PutExtra(SpawnSystem.NUM_SPAWNS_KEY, nSpawns);
        EventBroadcaster.Instance.PostEvent(EventNames.ON_SPAWN_BUTTON_CLICKED, parameters);
    }

    public void OnClearButtonClicked()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.ON_CLEAR_BUTTON_CLICKED);
    }

}
