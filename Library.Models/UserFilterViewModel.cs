using Library.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

public class UserFilterViewModel {
    public string Role { get; set; }
    public string Name { get; set; }
    public int? LocationID { get; set; }

    public List<User> Users { get; set; } = new List<User>();

    public List<SelectListItem> RoleList { get; set; }
    public List<SelectListItem> LocationList { get; set; }
}
