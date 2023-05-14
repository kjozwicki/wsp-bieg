using Logic;
using Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.ViewModel;

namespace ViewModel
{
    public class BoardViewModel : ViewModelBase
    {
        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public BoardViewModel()
        {
            viewModelBalls= new();
            WindowHeight = 720;
            WindowWidth = 1000;
            BoardModel = new BoardModel(WindowWidth, WindowHeight);
            StartCommand = new RelayCommandBase(Start);
            StopCommand = new RelayCommandBase(Stop);
        }

        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        private async void Start()
        {
            foreach(LogicBall LogicBall in BoardModel.GetStartingBallPositions(Count))
            {
                ModelBall ball = new ModelBall(LogicBall.GetX(), LogicBall.GetY(), LogicBall.GetRadius(), LogicBall.GetColor());
                viewModelBalls.Add(ball);
                LogicBall.PropertyChanged += ball.Update!;
            }
            BoardModel.StartThreads();
            while (BoardModel.Animating)
            {
                await Task.Delay(10);
                Balls = new ObservableCollection<ModelBall>(viewModelBalls);
            }
        }

        private void Stop()
        {
            BoardModel.Animating = false;
            BoardModel.InterruptThreads();
            viewModelBalls.Clear();
        }

        private ObservableCollection<ModelBall> viewModelBalls;
        public ObservableCollection<ModelBall> Balls
        {
            get => viewModelBalls;
            set
            {
                viewModelBalls = value;
                OnPropertyChanged(nameof(Balls));
            }
        }
        public int WindowHeight { get; }
        public int WindowWidth { get; }

        public BoardModel BoardModel { get; set; }
    }
}