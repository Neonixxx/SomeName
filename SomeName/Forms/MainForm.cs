using SomeName.Domain;
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
    public partial class MainForm : Form, ICanStart
    {
        public Player Player;

        public  FarmForm FarmForm = new FarmForm();

        public InventoryForm InventoryForm { get; set; }

        public FarmController FarmController { get; set; }

        public InventoryController InventoryController { get; set; }

        public GameController GameController { get; set; } = new GameController();

        public MainForm(Player player)
        {
            InitializeComponent();
            Player = player;
        }

        public void Start()
        {
            FarmController = new FarmController(Player, FarmForm);
            FarmForm.FarmController = FarmController;

            InventoryForm = new InventoryForm();
            InventoryController = new InventoryController
            {
                InventoryForm = InventoryForm,
                Player = Player,
                ShopManager = new ShopManager(),
                ForgeService = new ForgeService(Player),
                ShopService = new ShopService(Player)
            };
            InventoryForm.InventoryController = InventoryController;

            // HACK
            BattleDifficulty_ComboBox.Items.Clear();
            BattleDifficulty_ComboBox.Items.AddRange(GameController.BattleDifficulties);
            BattleDifficulty_ComboBox.SelectedIndex = GameController.GetCurrentDifficultyIndex();
            BattleDifficulty_ComboBox.SelectedIndexChanged += BattleDifficulty_ComboBox_SelectedIndexChanged;


            ShowDialog();
        }

        private void BattleDifficulty_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
            => GameController.SetBattleDifficulty(BattleDifficulty_ComboBox.SelectedIndex);

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Farm_Button_Click(object sender, EventArgs e)
        {
            this.StartForm(FarmController);
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            var isSaved = PlayerIO.TrySave(Player);
            if (isSaved)
                MessageBox.Show("Saved succesful.");
        }

        private void Inventory_Button_Click(object sender, EventArgs e)
        {
            this.StartForm(InventoryController);
        }
    }
}
