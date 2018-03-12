using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            return new List<GroupData>();
        }

        public void Add(GroupData newGroup)
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");

            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");

            
        }
    }
}