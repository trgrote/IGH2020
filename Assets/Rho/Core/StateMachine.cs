using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using rho;

namespace rho
{
    public class StateObj<T> where T : System.Enum
    {
        public T State;
        public Action<T> OnStateEnter;
        public Action<T> OnStateExit;

        public StateObj(T state)
        {
            State = state;
        }

        public StateObj<T> ConfigureOnEnter (Action<T> action)
        {
            OnStateEnter = action;
            return this;
        }

        public StateObj<T> ConfigureOnExit (Action<T> action)
        {
            OnStateExit = action;
            return this;
        }
    }
    public class StateMachine<T> where T : System.Enum
    {
        public T CurrentState { get; private set; }
        private List<StateObj<T>> Rules = new List<StateObj<T>>();

        private StateObj<T> GetStateObj(T state)
        {
            var item = Rules.FirstOrDefault(x => x.State.Equals(state));
            if (item == null)
            {
                item = new StateObj<T>(state);
                Rules.Add(item);
            }
            return item;
        }

        public StateMachine(T initialState)
        {
            CurrentState = initialState;
            Rules.Add(new StateObj<T>(initialState));
        }

        public StateObj<T> GetStateConfig(T state) => GetStateObj(state);

        public void ChangeState(T state)
        {
            // We grab the current state and the new state
            var oldState = GetStateObj(CurrentState);
            var newState = GetStateObj(state);
            // Execute the exit Action for the old state, if valid
            oldState.OnStateExit?.Invoke(state);
            // Execute entrance Action for new state, if valid
            newState.OnStateEnter?.Invoke(CurrentState);
            // Finally, new state is now the current state
            CurrentState = state;
        }
    }
}