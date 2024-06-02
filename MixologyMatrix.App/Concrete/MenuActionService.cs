using MixologyMatrix.App.Abstract;
using MixologyMatrix.Domain.Entity;

namespace MixologyMatrix.App.Concrete
{
    public class MenuActionService : IMenuActionService
    {
        public List<MenuAction> MenuActions { get; set; }

        public MenuActionService()
        {
            MenuActions = new List<MenuAction>();
        }

        public void AddNewAction(int id, string name, string menuName)
        {
            MenuAction menuAction = new MenuAction() { Id = id, Name = name, MenuName = menuName };
            MenuActions.Add(menuAction);
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in MenuActions)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }
    }
}