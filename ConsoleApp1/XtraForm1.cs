using ConsoleApp1.Model;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        private GridViewRowManager _gridViewRowManager { get; set; }
        private Random _rnd { get; set; } = new Random();

        public XtraForm1()
        {
            InitializeComponent();

            _gridViewRowManager = new GridViewRowManager(gc, gv);
        }

        private void GetRowModels(int index)
        {
            for (int i = 0; i < index; i++)
            {
                RowModel rowModel = new RowModel
                {
                    // _gridViewRowManager.Count defaut = 0
                    STT = _gridViewRowManager.Count + 1,
                    Status = "Add Row Success"
                };
                _gridViewRowManager.Add(rowModel);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                GetRowModels(Convert.ToInt32(sNumGenerator.Value));

                foreach (var model in _gridViewRowManager.Rows)
                {
                    ExecuteScript executeScript = new ExecuteScript
                    {
                        RowModel = model,
                        Total = _rnd.Next(0, 20)
                    };
                    executeScript.RowModelChanged += ExecuteScript_RowModelChanged;

                    Thread thread = new Thread(executeScript.Execute);
                    thread.Start();

                    Thread.Sleep(2000);
                }
            });
        }

        private void ExecuteScript_RowModelChanged(object sender, RowModel e)
        {
            RowModel rowModel = _gridViewRowManager.Rows.FirstOrDefault(row => row.STT == e.STT);
            if (rowModel != null)
            {
                rowModel.STT = e.STT;
                _gridViewRowManager.RefreshDataSource();
            }
        }
    }
}