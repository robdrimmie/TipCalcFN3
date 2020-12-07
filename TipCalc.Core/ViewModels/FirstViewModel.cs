using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace TipCalc.Core.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        public IMvxAsyncCommand NavigateCommand { get; protected set; }
        public IMvxNavigationService _mvxNavigationService;

        public int Generosity { get; set; }
        public double SubTotal { get; set; }
        
        public FirstViewModel(IMvxNavigationService mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
            NavigateCommand = new MvxAsyncCommand(NavToSecond);
        }

        protected override void IglooPrepare(IBaseViewModelParameters parameter)
        {
            FirstViewModelParameters firstViewModelParameters = (FirstViewModelParameters)parameter;

            Generosity = firstViewModelParameters.Generosity;
            SubTotal = firstViewModelParameters.Subtotal;
        }

        public Task NavToSecond()
        {
            FirstViewModelParameters firstViewModelParameters = new FirstViewModelParameters()
            {
                Subtotal = 1,
                Generosity = 2
            };

            return Task.FromResult<bool>(
                _mvxNavigationService.Navigate<SecondViewModel>().GetAwaiter().GetResult()
            );
        }
    }

    public class FirstViewModelParameters:IBaseViewModelParameters
    {
        public int Generosity { get; set; }
        public double Subtotal { get; set; }
    }
}
