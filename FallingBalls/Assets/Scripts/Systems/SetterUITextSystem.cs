using Components;
using Components.Events;
using Leopotam.Ecs;

namespace Systems
{
    internal class SetterUITextSystem : IEcsRunSystem
    {
        private EcsFilter<EventChangeText, UITextComponent, MessageComponent> _setterFilter;

        public void Run()
        {
            foreach (var indexEntity in _setterFilter)
            {
                ref var textUIComponent = ref _setterFilter.Get2(indexEntity);

                ref var messageComponent = ref _setterFilter.Get3(indexEntity);

                textUIComponent.UIText.SetText(ref textUIComponent, ref messageComponent);
            }
        }
    }
}