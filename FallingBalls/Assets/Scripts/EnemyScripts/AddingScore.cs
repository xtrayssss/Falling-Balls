using Components;

namespace EnemyScripts
{
    internal class AddingScore
    {
        private int _score;
        
        public void AddScore(ref ScoreComponent scoreComponent) => 
            _score += scoreComponent.Score;

        public int GetScore() => 
            _score;
    }
}