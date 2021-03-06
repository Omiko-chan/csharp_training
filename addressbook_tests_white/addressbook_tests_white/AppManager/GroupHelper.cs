﻿using System;
using System.Collections.Generic;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;


namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";

        public GroupHelper(ApplicationManager manager) : base(manager) { }


        public void PreconditionsGroup(GroupData groupData)
        {
            List<GroupData> groups = GetGroupList();
            if (groups.Count == 0)
            {
                Add(groupData,0);
            }
        }

        //удаление
        public void Remove(int p)
        {
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            root.Nodes[0].Select();
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            dialogue.Get<Button>("uxOKAddressButton").Click();                      
            CloseGroupsDialogue(dialogue);

        }


        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue= OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
            CloseGroupsDialogue(dialogue);
            return list;

        }
        public List<GroupData> GetGroupList(int level)
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0].Nodes[level];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
            CloseGroupsDialogue(dialogue);
            return list;

        }

        public void Add(GroupData newGroup, int level)
        {
            Window dialogue = OpenGroupsDialogue();
            if (level == 1)
            {
                Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
                TreeNode root = tree.Nodes[0];
                root.Nodes[0].Select();
            }
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox=(TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);


            CloseGroupsDialogue(dialogue);

        }

        private void CloseGroupsDialogue(Window dialogue)
        {
           dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        private Window OpenGroupsDialogue()
        {
            //List<Window> win = manager.MainWindow.ModalWindows();
            //if (win.Count==0)
            //{
                manager.MainWindow.Get<Button>("groupButton").Click();
            //}
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }
    }
}