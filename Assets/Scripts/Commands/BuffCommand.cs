using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffCommand : ICommand
{
    IBuffable _buffableToken;

    // Pulls in all dependencies in the Constructor & then stores in field vars
    public BuffCommand(IBuffable buffableToken)
    {
        _buffableToken = buffableToken;
    }

    public void Execute()
    {
        _buffableToken.Buff();
    }

    public void Undo()
    {
        _buffableToken.Unbuff();
    }
}
