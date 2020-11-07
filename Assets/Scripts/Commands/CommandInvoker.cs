using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    // private static to limit access but allow static functions
    // If you ‘Push’ to the stack, you are just piling another thing on top. 
    // If you ‘Pop’ from the stack, you are pulling the top thing off. 
    private Stack<ICommand> CommandHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        CommandHistory.Push(command);
        command.Execute();
    }

    public void UndoCommand()
    {
        // Guard clause
        if (CommandHistory.Count <= 0)
            return;

        CommandHistory.Pop().Undo();
    }
}
