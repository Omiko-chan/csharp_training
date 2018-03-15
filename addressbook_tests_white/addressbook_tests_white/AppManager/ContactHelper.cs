using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;

namespace addressbook_tests_white
{
    public class ContactHelper : HelperBase
    {
        public static string CONTACTWINTITLE = "Contact Editor";

        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();
            Window mainWindow = manager.MainWindow;
            Table table = mainWindow.Get<Table>("uxAddressGrid");
            TableRows tableRows = table.Rows;

            foreach (TableRow item in tableRows)
            { list.Add(new ContactData()
            {
                Firstname = item.Cells[0].Value as string,
                Lastname=item.Cells[1].Value as string

              });
            }

            return list;
        }

        public void Add(ContactData contactData)
        {
            Window dialogue= OpenContactsDialogue();
            TextBox textBoxF = dialogue.Get<TextBox>("ueFirstNameAddressTextBox");
           // textBoxF.Click();
            textBoxF.Enter(contactData.Firstname);
            TextBox textBoxL = dialogue.Get<TextBox>("ueLastNameAddressTextBox");
           // textBoxL.Click();
            textBoxL.Enter(contactData.Lastname);
            CloseContactDialogue(dialogue);
        }

        public void Remove(int v)
        {
            Window mainWindow = manager.MainWindow;
            Table table = mainWindow.Get<Table>("uxAddressGrid");
            TableRows tableRows = table.Rows;
            tableRows[0].Select();
            mainWindow.Get<Button>("uxDeleteAddressButton").Click();
            Window question = mainWindow.ModalWindow("Question");
            question.Get<Button>(SearchCriteria.ByText("Yes")).Click();     
        }

        private Window OpenContactsDialogue()
        {
            manager.MainWindow.Get<Button>("uxNewAddressButton").Click();
            return manager.MainWindow.ModalWindow(CONTACTWINTITLE);
        }

        private void CloseContactDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxSaveAddressButton").Click();
        }

        public void PreconditionsContact(ContactData contactData)
        {
            List<ContactData> contacts = GetContactList();
            if (contacts.Count == 0)
            {
                Add(contactData);
            }
        }
    }
}
