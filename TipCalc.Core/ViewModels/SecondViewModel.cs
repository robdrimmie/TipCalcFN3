using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace TipCalc.Core.ViewModels
{
    public class SecondViewModel : FirstViewModel
    {
        public string Message { get; set; }

        public SecondViewModel(
            IMvxNavigationService mvxNavigationService
        ) : base(mvxNavigationService)
        {
            NavigateCommand = new MvxAsyncCommand(NavToFirst);
        }

        public Task NavToFirst()
        {
            FirstViewModelParameters firstViewModelParameters = new FirstViewModelParameters()
            {
                Subtotal = 20,
                Generosity = 40
            };

            return Task.FromResult<bool>(
                _mvxNavigationService.Navigate<FirstViewModel, FirstViewModelParameters>(firstViewModelParameters).GetAwaiter().GetResult()
            );
        }
    }
}
