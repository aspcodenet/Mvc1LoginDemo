using System.Collections.Generic;

namespace Mvc1LoginDemo.ViewModels
{
    public class AdminRolesIndexViewModel
    {
        public List<AdminRoleItem> Items { get; set; }

        public class AdminRoleItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}