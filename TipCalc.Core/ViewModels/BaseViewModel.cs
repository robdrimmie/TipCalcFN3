using MvvmCross.ViewModels;

namespace TipCalc.Core.ViewModels
{
    public interface IBaseViewModelParameters {}

    public abstract class BaseViewModel: MvxViewModel<IBaseViewModelParameters>
    {
        private IBaseViewModelParameters _baseViewModelParameters;

        public BaseViewModel()
        {
        }

        public override void Prepare(IBaseViewModelParameters baseViewModelParameters)
        {
            _baseViewModelParameters = baseViewModelParameters;

        }

        protected abstract void IglooPrepare(IBaseViewModelParameters baseViewModelParameters);
    }
}
