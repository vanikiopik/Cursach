public class StateMachine
{
    private CharacterState currentState;
    public void SetState(CharacterState newState)
    {
        if (currentState != null)
            currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
    public void Update()
    {
        if (currentState != null)
            currentState.Update();
    }
}
