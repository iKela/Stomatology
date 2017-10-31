using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stomatology
{
    public partial class UserInfo : Form
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            //foreach (TreeNode tn in treeView1.Nodes)
            //{
            //    // get parent node here
            //    foreach (TreeNode child in tn.Nodes)
            //    {
            //        //get child node here
            //    }
            //}
        }
    }
}
