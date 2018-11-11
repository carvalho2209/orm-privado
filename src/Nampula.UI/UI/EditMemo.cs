using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
namespace Nampula.UI
{

    public class EditMemo : DevExpress.XtraEditors.MemoEdit
    {
        /// <summary>
        /// Informações da fonte de dados
        /// </summary>
        public string DataSourceInformation { get; set; }
    }

}
