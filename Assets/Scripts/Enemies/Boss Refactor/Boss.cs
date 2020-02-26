using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public List<BossBehaviour> behaviourLoop;

    private int currentBehaviourIndex = 0;
    private int totalbehaviours;
    private BossBehaviour currentBehaviour;

    private void Awake()
    {
        Debug.Assert(behaviourLoop.Count > 0, "No behaviours in behaviour loop");
        totalbehaviours = behaviourLoop.Count;
    }

    private void Start()
    {
        currentBehaviour = behaviourLoop[0];
        currentBehaviour.StartBehaviour();
    }

    private void Update()
    {
        UpdateBehaviour();
    }

    private void UpdateBehaviour()
    {
        if (currentBehaviour.isComplete)
        {
            GoToNextBehaviour();
        }
    }

    private void GoToNextBehaviour()
    {
        currentBehaviour.Reset();
        currentBehaviourIndex = (currentBehaviourIndex + 1) % totalbehaviours;
        currentBehaviour = behaviourLoop[currentBehaviourIndex];
        currentBehaviour.StartBehaviour();
    }
}
