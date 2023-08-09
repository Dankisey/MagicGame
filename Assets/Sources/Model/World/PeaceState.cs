using System;

namespace Game.Model
{
    public class ExploreState : IState
    {
        public Action Entered;
        public Action Ended;

        public void Enter()
        {
            Entered?.Invoke(); 
        }

        public void Exit()
        {
            Ended?.Invoke();
        }
    }
}