using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ExecuteScript
    {
        public event EventHandler<RowModel> RowModelChanged;

        public RowModel RowModel { get; set; }
        public int Total { get; set; }

        private Random rnd = new Random(new Random().Next());

        public void Execute()
        {
            for (int i = 0; i < Total; i++)
            {
                string status = rnd.Next(0, 1000).ToString();
                ChangeStatus($"Total : {Total} | Status : {status}");

                Thread.Sleep(1000);
            }

            ChangeStatus("Done");
        }

        private void ChangeStatus(string stt)
        {
            RowModel.Status = stt;
            RowModelChanged?.Invoke(this, RowModel);
        }
    }
}
