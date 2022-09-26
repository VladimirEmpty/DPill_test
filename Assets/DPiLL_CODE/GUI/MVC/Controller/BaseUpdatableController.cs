using DPiLL_CODE.GUI.MVC.View;
using DPiLL_CODE.GUI.MVC.Model;

namespace DPiLL_CODE.GUI.MVC.Controller
{
    public abstract class BaseUpdatableController<T, M> : BaseController<T, M>, IUpdatableController
        where T : class, IView
        where M : class, IModel, new()
    {
        public abstract string Tag { get; }

        public void UpdateController(string updateTag)
        {
            if (!string.IsNullOrEmpty(updateTag) & !Tag.Equals(updateTag))
                return;

            UpdateView();
        }
    }
}
