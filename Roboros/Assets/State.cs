using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{


    public enum state
    {
        ONE_ARM = 2,
        TWO_ARMS = 4,
        HUMAN = 6
    };

    [SerializeField] public state currState = state.ONE_ARM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
