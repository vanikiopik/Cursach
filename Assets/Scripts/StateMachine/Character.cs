using UnityEngine;

public class Character : MonoBehaviour
{
    private StateMachine stateMachine;
    private CharacterState walkingState;
    private CharacterState runningState;
    private void Start()
    {
        stateMachine = new StateMachine();
        walkingState = new WalkingState(this);
        runningState = new RunningState(this);

        stateMachine.SetState(walkingState);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void SetWalkingState()
    {
        stateMachine.SetState(walkingState);
    }

    public void SetRunningState()
    {
        stateMachine.SetState(runningState);
    }
}
