using Components;
using Interfaces;

namespace PlayerScripts
{
    internal class ScoreSetter : IUIText
    {
        public void SetText(ref UITextComponent textUIComponent ,ref MessageComponent messageComponent)
        {
            textUIComponent.FirstText.SetText(messageComponent.FirstMessage);

            textUIComponent.SecondText.SetText(messageComponent.SecondMessage);

            textUIComponent.ThirdText.SetText(messageComponent.ThirdMessage);
        }
    }
}