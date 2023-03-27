using UnityEngine.TextCore.Text;

public abstract class CharacterState
{
    protected Character character;
    public CharacterState(Character character)
    {
        this.character = character;
    }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
