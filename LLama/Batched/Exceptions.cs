﻿using System;

namespace LLama.Batched;

/// <summary>
/// Base class for exceptions thrown from <see cref="BatchedExecutor"/>
/// </summary>
public class ExperimentalBatchedExecutorException
    : Exception
{
    internal ExperimentalBatchedExecutorException(string message)
        : base(message)
    {
    }
}

/// <summary>
/// This exception is thrown when "Prompt()" is called on a <see cref="Conversation"/> which has
/// already been prompted and before "Infer()" has been called on the associated
/// <see cref="BatchedExecutor"/>.
/// </summary>
public class AlreadyPromptedConversationException
    : ExperimentalBatchedExecutorException
{
    internal AlreadyPromptedConversationException()
        : base("Must call `Infer()` before prompting this Conversation again")
    {
    }
}

/// <summary>
/// This exception is thrown when "Sample()" is called on a <see cref="Conversation"/> which has
/// already been prompted and before "Infer()" has been called on the associated
/// <see cref="BatchedExecutor"/>.
/// </summary>
public class CannotSampleRequiresInferenceException
    : ExperimentalBatchedExecutorException
{
    internal CannotSampleRequiresInferenceException()
        : base("Must call `Infer()` before sampling from this Conversation")
    {
    }
}

/// <summary>
/// This exception is thrown when "Sample()" is called on a <see cref="Conversation"/> which was not
/// first prompted.
/// <see cref="BatchedExecutor"/>.
/// </summary>
public class CannotSampleRequiresPromptException
    : ExperimentalBatchedExecutorException
{
    internal CannotSampleRequiresPromptException()
        : base("Must call `Prompt()` and then `Infer()` before sampling from this Conversation")
    {
    }
}

/// <summary>
/// This exception is thrown when "Fork()" is called on a <see cref="Conversation"/> with <see cref="Conversation.RequiresInference"/> = true
/// </summary>
public class CannotForkWhileRequiresInference
    : ExperimentalBatchedExecutorException
{
    internal CannotForkWhileRequiresInference()
        : base("Cannot `Fork()` a conversation while RequiresInference is true")
    {
    }
}

/// <summary>
/// This exception is thrown when "Rewind()" is called on a <see cref="Conversation"/> with <see cref="Conversation.RequiresInference"/> = true
/// </summary>
public class CannotRewindWhileRequiresInference
    : ExperimentalBatchedExecutorException
{
    internal CannotRewindWhileRequiresInference()
        : base("Cannot `Rewind()` a conversation while RequiresInference is true")
    {
    }
}