using Components;
using Leopotam.Ecs;

namespace PlayerScripts
{
    internal class ScoreTextUpdater
    {
        private readonly RecordSaver _recordSaver;

        public ScoreTextUpdater(RecordSaver recordSaver)
        {
            _recordSaver = recordSaver;
        }

        public void TextsUpdate(EcsEntity playerEntity, int score, ref CounterComponent counterComponent,
            string namePlayerPrefs, int defaultValue)
        {
            ref var messageComponent = ref playerEntity.Get<MessageComponent>();

            SetScoreMessage(ref messageComponent, score);

            SetRecordMessage(ref messageComponent, namePlayerPrefs, defaultValue);

            SetDestroyedBalls(ref counterComponent, ref messageComponent);
        }

        private void SetDestroyedBalls(ref CounterComponent counterComponent,
            ref MessageComponent messageComponent)
        {
            if (counterComponent.Count == 0)
            {
                messageComponent.ThirdMessage =
                    "Destroyed Balls: " + 1;

                counterComponent.Count += 1;
            }
            else
            {
                messageComponent.ThirdMessage =
                    "Destroyed Balls: " + counterComponent.Count;
            }
        }

        private void SetRecordMessage(ref MessageComponent messageComponent, string namePlayerPrefs,
            int defaultValue) =>
            messageComponent.SecondMessage =
                "You Record: " + _recordSaver.GetPlayerPrefs(namePlayerPrefs, defaultValue);

        private void SetScoreMessage(ref MessageComponent messageComponent, int score) =>
            messageComponent.FirstMessage = "Score: " + score;
    }
}