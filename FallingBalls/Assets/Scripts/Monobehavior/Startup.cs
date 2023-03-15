using System.Linq;
using Systems;
using Components.Events;
using Containers;
using EnemyScripts;
using EventsBus;
using Helper;
using Leopotam.Ecs;
using UnityEngine;

namespace Monobehavior
{
    public class Startup : MonoBehaviour
    {
        private EcsWorld _world;

        private EcsSystems _initSystem;
        private EcsSystems _systemFixedUpdate;
        private EcsSystems _systemUpdate;

        private PlayerInputHandler _playerInputHandler;

        private readonly CalculatorBoundsScreen _calculatorBoundsScreen = new CalculatorBoundsScreen();

        private readonly Pool _enemyPool = new Pool();

        private readonly DamageableBehavior _damageableBehavior = new DamageableBehavior();

        [SerializeField] private PauseMenuHandler pauseMenuHandler;

        [SerializeField] private GameObject gameOverMenuGO;

        [SerializeField] private ContainerUI containerUI;

        private void Awake()
        {
            Constants.ResetStaticVariables();
            EventBus.PlayerCreated += OnCreatePlayer;

            _world = new EcsWorld();

            _systemUpdate = new EcsSystems(_world);

            _initSystem = new EcsSystems(_world);

            _systemFixedUpdate = new EcsSystems(_world);

            _calculatorBoundsScreen.CalculatedBounds();

            AddSystems();

            AddOneFrames();

            _initSystem.Init();
            _systemUpdate.Init();
            _systemFixedUpdate.Init();
        }

        private void Start()
        {
            containerUI.recordScoreText.SetText("You Record: " + PlayerPrefs.GetInt("RecordScore", 0));

            Cursor.SetCursor(containerUI.cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        }

        private void OnDisable() => 
            EventBus.PlayerCreated -= OnCreatePlayer;

        private void Update()
        {
            if (!pauseMenuHandler.IsPausedGame())
            {
                _systemUpdate.Run();
            }
        }

        private void FixedUpdate()
        {
            if (!pauseMenuHandler.IsPausedGame())
            {
                _systemFixedUpdate.Run();
            }
        }

        private void OnDestroy()
        {
            _initSystem.Destroy();
            _systemFixedUpdate.Destroy();
            _systemUpdate.Destroy();
            _world.Destroy();
        }

        private void AddOneFrames()
        {
            _systemUpdate
                .Inject(_calculatorBoundsScreen)
                .OneFrame<EventResetComponent>()
                .OneFrame<EventSpawn>()
                .OneFrame<EventChangeCounter>()
                .OneFrame<EventHitEnemy>()
                .OneFrame<EventDestroyEntity>()
                .OneFrame<EventChangeText>()
                .OneFrame<EventChangeHealth>();
        }

        private void AddSystems()
        {
            _initSystem
                .Add(new PlayerInitSystem(containerUI.fillBackImage,
                    containerUI.fillFrontImage,
                    containerUI.scoreText,
                    containerUI.recordScoreText, containerUI.destroyedBallsText, gameOverMenuGO))
                .Add(new InitEnemySystem(_enemyPool, _damageableBehavior,
                    _calculatorBoundsScreen.TopLeftPosition + Constants.LeftOffsetSpawn,
                    _calculatorBoundsScreen.TopRightPosition + Constants.RightOffsetSpawn))
                .Add(new PoolInitSystem(_enemyPool));


            _systemUpdate
                .Add(new SpawnEntitySystem())
                .Add(new HittingEnemySystem())
                .Add(new BoundsCheckerSystem())
                .Add(new HealthCheckerSystem())
                .Add(new DestroyEntitySystem())
                .Add(new CounterSystem())
                .Add(new SetterUITextSystem())
                .Add(new SwitcherComplexityGameSystem())
                .Add(new ResetComponentSystem())
                .Add(new BlockTimerSystem())
                .Add(new HealthBarSystems())
                .Add(new TimerTickSystem());
        }

        private void OnCreatePlayer(GameObject player)
        {
            _playerInputHandler = player.GetComponent<PlayerInputHandler>();

            _systemUpdate.Add(new PlayerInputSystem(_playerInputHandler));
            _systemUpdate.Add(new PlayerClickHandlerSystem(_playerInputHandler));
        }
    }
}