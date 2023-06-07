using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rezervq
{
    internal class ToDoModel
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

        private bool _isRezerv;
        public bool IsRezerv
        {
         get { return _isRezerv; }
         set { _isRezerv = value; } }
        }
    }
}
