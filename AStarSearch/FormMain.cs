using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AStarSearch
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonBrowseMapSourceFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxMapSourceFile.Text = this.openFileDialog.FileName;
            }
        }

        private void buttonFindPath_Click(object sender, EventArgs e)
        {
            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;
            this.labelGoalInfo.Text = "Searching for Path . . .";
            this.labelGoalInfo.Visible = true;

            if (String.IsNullOrEmpty(this.textBoxPathResultFile.Text))
            {
                MessageBox.Show("Must specify Result File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AStar2DMapSearcher mapSearcher = new AStar2DMapSearcher(
                    this.checkBoxAllowDiagonalMovement.Checked,
                    this.radioButtonChebyshev.Checked,
                    this.checkBoxGenerateDebugOutputFile.Checked);

                string mapSourceFile = this.textBoxMapSourceFile.Text;
                string directory = Path.GetDirectoryName(mapSourceFile);
                string mapPathDestinationFile = Path.Combine(directory, this.textBoxPathResultFile.Text);

                AStarPriorityQueueNode goalNode = null;

                if (mapSearcher.SearchPath(mapSourceFile, mapPathDestinationFile, out goalNode))
                {
                    MessageBox.Show("A Path was found and result was written to: " + mapPathDestinationFile, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (goalNode != null)
                    {
                        this.labelGoalInfo.Text = "The cost to the goal node is: " + goalNode.MapNode.CostF.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("A Path could not be found.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
        }

        private void checkBoxAllowDiagonalMovement_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxAllowDiagonalMovement.Checked)
            {
                this.groupBoxHeuristicChoice.Enabled = true;
                this.radioButtonChebyshev.Checked = true;
            }
            else
            {
                this.groupBoxHeuristicChoice.Enabled = false;
                this.radioButtonManhattan.Checked = true;
            }
        }
    }
}
