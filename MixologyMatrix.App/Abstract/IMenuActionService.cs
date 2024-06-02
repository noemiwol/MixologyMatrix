using MixologyMatrix.Domain.Entity;

namespace MixologyMatrix.App.Abstract
{
    public interface IMenuActionService
    {
        List<MenuAction> MenuActions { get; set; }

        void AddNewAction(int id, string name, string menuName);

        List<MenuAction> GetMenuActionsByMenuName(string menuName);
    }
}