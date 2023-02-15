﻿using System;
using System.Collections.Generic;
using Features.GameStates.Factory;
using Features.GameStates.States.Interfaces;
using Zenject;

namespace Features.GameStates
{
  public class GameStateMachine : IGameStateMachine
  {
    private readonly GameStatesFactory factory;
    private readonly Dictionary<Type, IExitableState> states;
    private IExitableState activeState;
    
    public GameStateMachine(GameStatesFactory factory)
    {
      this.factory = factory;
      states = new Dictionary<Type, IExitableState>(5);
    }

    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    public TState GetState<TState>() where TState : class, IExitableState
    {
      if (states.ContainsKey(typeof(TState)) == false)
        states.Add(typeof(TState), factory.Create<TState>(this));
      
      return states[typeof(TState)] as TState;
    }


    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      activeState?.Exit();
      
      TState state = GetState<TState>();
      activeState = state;
      
      return state;
    }
  }
}