namespace GFFramework.UI
{
    public interface IViewControl
    {
        DataListenerService Model { get; }

        void BindModel();
        void Enter();
        void Exit();
    }
}