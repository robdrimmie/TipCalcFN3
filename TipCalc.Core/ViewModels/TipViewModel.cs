using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculationService _calculationService;
        private readonly IMvxNavigationService _navigationService;

        public TipViewModel(
            ICalculationService calculationService,
            IMvxNavigationService mvxNavigationService)
        {
            _calculationService = calculationService;
            _navigationService = mvxNavigationService;

            NavigateCommand = new MvxAsyncCommand(NavToFirst);
        }

        public Task NavToFirst()
        {
            FirstViewModelParameters firstViewModelParameters = new FirstViewModelParameters()
            {
                Subtotal = 1,
                Generosity = 2
            };

            return Task.FromResult<bool>(
                _navigationService.Navigate<FirstViewModel, FirstViewModelParameters>(firstViewModelParameters).GetAwaiter().GetResult()
            );
        }

        public IMvxAsyncCommand NavigateCommand { get; private set; }

        public override async Task Initialize()
        {
            await base.Initialize();

            SubTotal = 100;
            Generosity = 10;
            Recalcuate();
        }

        private double _subTotal;
        public double SubTotal
        {
            get => _subTotal;
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => SubTotal);

                Recalcuate();
            }
        }

        private int _generosity;
        public int Generosity
        {
            get => _generosity;
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => Generosity);

                Recalcuate();
            }
        }

        private double _tip;
        public double Tip
        {
            get => _tip;
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        private void Recalcuate()
        {
            Tip = _calculationService.TipAmount(SubTotal, Generosity);
        }
    }
}
