using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public List<BossBehaviour> behaviourLoop;

    private int currentBehaviourIndex = 0;
    private int totalbehaviours;
    private BossBehaviour currentBehaviour;
    [HideInInspector] public bool atePoison = false;
    private bool didSpit = false;

    private void Awake()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
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

        CheckBehaviourSkips();

        currentBehaviour.StartBehaviour();
    }

    private void CheckBehaviourSkips()
    {
        // If we are about to do the spit up attack, and a poison block has been eaten, instead skip to swell up
        if (currentBehaviour is BossSpitUpAttack)
        {
            if (atePoison)
            {
                atePoison = false;
                currentBehaviourIndex = (currentBehaviourIndex + 1) % totalbehaviours;
                currentBehaviour = behaviourLoop[currentBehaviourIndex];
            }
            else
            {
                didSpit = true;
            }
            
        }
        // If we have just spit up, we want to skip the swell up attack
        else if (currentBehaviour is BossSwellUpAttack && didSpit)
        {
            didSpit = false;
            currentBehaviourIndex = (currentBehaviourIndex + 1) % totalbehaviours;
            currentBehaviour = behaviourLoop[currentBehaviourIndex];
        }
    }
}
