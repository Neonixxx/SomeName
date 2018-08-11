using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomeName.Forms
{
    public partial class Main_Form : Form, ICanStart
    {
        public Player Player;

        public  Farm_Form FarmForm = new Farm_Form();

        public Inventory_Form InventoryForm { get; set; }

        public FarmController FarmController { get; set; }

        public InventoryController InventoryController { get; set; }

        public Main_Form(Player player)
        {
            InitializeComponent();
            Player = player;
        }

        public void Start()
        {
            FarmController = new FarmController(Player, FarmForm);
            FarmForm.FarmController = FarmController;

            InventoryForm = new Inventory_Form();
            InventoryController = new InventoryController
            {
                InventoryForm = InventoryForm,
                Player = Player
            };
            InventoryForm.InventoryController = InventoryController;

            ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Farm_Button_Click(object sender, EventArgs e)
        {
            this.StartForm(FarmForm);
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            var isSaved = PlayerIO.TrySave(Player);
            if (isSaved)
                MessageBox.Show("Saved succesful.");
        }

        private void Inventory_Button_Click(object sender, EventArgs e)
        {
            this.StartForm(InventoryForm);
        }
    }
}
