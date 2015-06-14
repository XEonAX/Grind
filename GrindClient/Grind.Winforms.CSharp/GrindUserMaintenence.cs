using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Grind.Common;
namespace Grind.Winforms.CSharp
{
    public partial class GrindUserMaintenence : UserControl
    {
        public GrindUserMaintenence()
        {
            InitializeComponent();
        }
        public Person person = new Person();
        bool Refreshed = false;
        private void lbPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Refreshed)
            {
                person = Globals.People[lbPeople.SelectedIndex];
                FillForm(person);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            person.name = txtName.Text;
            person.trigram = txtTrigram.Text;
            person.internal_object_id = txtIntObjId.Text;
            person.active = chkActive.Checked;
            person.level = (eLevel)dupLevel.SelectedIndex;
            Controllers.CreatePerson(person);
            btnRefresh_Click(null, EventArgs.Empty);
            Refreshed = true;
            lbPeople.SelectedIndex = lbPeople.Items.Count - 1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refreshed = false;
            Controllers.ReadPeople(out Globals.People);
            lbPeople.DataSource = Globals.People.Select(x => x.name).ToList();
            //if (OldSelectedIndex > lbPeople.Items.Count-1)
            //    OldSelectedIndex = lbPeople.Items.Count - 1;
            //else if ((OldSelectedIndex < lbPeople.Items.Count-1) && (OldSelectedIndex == -1))
            //{
            //    OldSelectedIndex = 0;
            //}
            //else 
            if (sender != null) Refreshed = true;
            if (lbPeople.SelectedIndex == -1)
            {
                FillForm(new Person());
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

            }
            Refreshed = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int OldSelectedIndex = lbPeople.SelectedIndex;
            person.name = txtName.Text;
            person.trigram = txtTrigram.Text;
            person.internal_object_id = txtIntObjId.Text;
            person.active = chkActive.Checked;
            person.level = (eLevel)dupLevel.SelectedIndex;
            Controllers.UpdatePerson(person);
            btnRefresh_Click(null, EventArgs.Empty);
            Refreshed = true;
            lbPeople.SelectedIndex = OldSelectedIndex;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int OldSelectedIndex = lbPeople.SelectedIndex;
            if (lbPeople.SelectedIndex >= 0)
            {
                person = Globals.People[lbPeople.SelectedIndex];
                Controllers.DeletePerson(person);
            }
            btnRefresh_Click(null, EventArgs.Empty);
            Refreshed = true;
            if (OldSelectedIndex > lbPeople.Items.Count - 1)
                OldSelectedIndex = lbPeople.Items.Count - 1;
            lbPeople.SelectedIndex = OldSelectedIndex;
        }


        private void FillForm(Person person)
        {
            txtName.Text = person.name;
            txtTrigram.Text = person.trigram;
            txtIntObjId.Text = person.internal_object_id;
            chkActive.Checked = person.active;
            dupLevel.SelectedIndex = (int)person.level;
        }

        private void GrindUserMaintenence_Load(object sender, EventArgs e)
        {
            dupLevel.SelectedIndex = 0;
        }

        private void Form_TextChanged(object sender, EventArgs e)
        {
            if ((txtName.Text.Trim().Length == 0) || (txtTrigram.Text.Trim().Length == 0) || (txtIntObjId.Text.Trim().Length == 0))
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
                if (lbPeople.SelectedIndex != -1)
                    btnUpdate.Enabled = true;
            }

        }


    }
}
