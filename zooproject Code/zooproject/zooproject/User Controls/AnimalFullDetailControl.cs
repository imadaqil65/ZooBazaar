using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.Zoo;

namespace zooproject.User_Controls
{
    public partial class AnimalFullDetailControl : UserControl
    {
        AddAnimal addAnimal;
        public AnimalFullDetailControl(AddAnimal addanimal, string name, AnimalSpecies species, DateTime dateofbirth, DateTime enterdate, Gender gender, bool isPredator, bool isPrey, string diet, string notes, string origin, string relations)
        {
            InitializeComponent();
            this.addAnimal = addanimal;
            if (!string.IsNullOrEmpty(name)) { textBox_Name.Text = name; }
            if (!string.IsNullOrEmpty(species.ToString())) { textBox_Species.Text = species.ToString(); }
            if (!string.IsNullOrEmpty(dateofbirth.Date.ToString())) { textBox_Birthday.Text = dateofbirth.Date.ToString(); }
            if (!string.IsNullOrEmpty(enterdate.Date.ToString())) { textBox_MoveInDate.Text = enterdate.Date.ToString(); }
            if (!string.IsNullOrEmpty(gender.ToString())) { textBox_Gender.Text = gender.ToString(); }
            if (isPredator == true) { checkBox_AddAnimal_Predatory.Checked = true; }
            if (isPrey == true) { checkBox_AddAnimal_Prey.Checked = true; }
            if (!string.IsNullOrEmpty(diet)) { richTextBox_Diet.Text = diet; }
            if (!string.IsNullOrEmpty(notes)) { richTextBox_Notes.Text = notes; }
        }
    }
}
