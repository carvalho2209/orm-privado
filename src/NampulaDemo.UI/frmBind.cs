using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Nampula.UI.Helpers;
using Nampula.UI.Helpers.Extentions;
using NampulaDemo.DI;
using NampulaDemo.DI.Factory;
using Nampula.DI;
using System.Linq;

namespace NampulaDemo
{
    public partial class frmBind : Nampula.UI.Form
    {
        Dictionary<string, Control> _binds = new Dictionary<string, Control>();
        People _people = DI.Factory.DBTeste.CreateObject<People>();
        public frmBind()
        {
            InitializeComponent();

            _binds.Add(People.FieldsName.Id, txtId);
            _binds.Add(People.FieldsName.Name, txtName);
            _binds.Add(People.FieldsName.Gender, comboBox1);
            _binds.Add(People.FieldsName.Married, checkBox1);
            _binds.Add(People.FieldsName.BirthDate, editDateTime1);

            _binds.SetDataSourceInformation(_people);


            comboBox1.FillValues<Gender>(new DBTeste(), Gender.FieldsName.ID, Gender.FieldsName.Description, 0);
            gridView1.FormatGrid<PeopleAddress>(new DBTeste(), true);
            SetTextButton(buttonOK, GetFormState(_people));
            buttonOK.Click += buttonOK_Click;
        }

        void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (_people.StateRecord == Nampula.DI.eState.eDatabase)
                    Close();

                
                _binds.FillClass(_people);

                if (_people.StateRecord == eState.eAdd)
                    _people.Add();
                else if (_people.StateRecord == eState.eUpdate)
                    _people.Update();

                _people.StateRecord = Nampula.DI.eState.eDatabase;
                SetTextButton(buttonOK, GetFormState(_people));
                ShowSucessfullMessage();
                _binds.FillControls(_people);
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private Nampula.UI.BoFormMode GetFormState(People _people)
        {
            switch (_people.StateRecord)
            {
                case Nampula.DI.eState.eDatabase:
                    return Nampula.UI.BoFormMode.fm_OK_MODE;
                case Nampula.DI.eState.eAdd:
                    return Nampula.UI.BoFormMode.fm_ADD_MODE;
                case Nampula.DI.eState.eUpdate:
                    return Nampula.UI.BoFormMode.fm_UPDATE_MODE;
                case Nampula.DI.eState.eRemove:
                    return Nampula.UI.BoFormMode.fm_VIEW_MODE;
                default:
                    return Nampula.UI.BoFormMode.fm_VIEW_MODE;
            }
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            try
            {

                new ChangeLogForm(_people).ShowDialog(this);
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void toolStripButtonPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (_people.StateRecord == eState.eAdd || _people.Id == 0)
                    _people = GetFirstRecord();
                else
                    _people = GetPrevRecord();

                _people.SetModifyState();
                _binds.FillControls(_people);
                SetTextButton(buttonOK, GetFormState(_people));
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private People GetPrevRecord()
        {
            var people = DBTeste.CreateObject<People>();
            var tbQry = new TableQuery(people);
            tbQry.Top = 1;
            tbQry.Where.Add(new QueryParam(people.Collumns[People.FieldsName.Id], eCondition.ecLessThan, _people.Id));

            var list = people.FillCollection<People>(tbQry);
            if (list.Count == 0)
                throw new Exception("Nenhum registro encontrado");
            else
                return list.First();
        }

        private People GetFirstRecord()
        {
            var people = DBTeste.CreateObject<People>();
            var tbQry = new TableQuery(people);
            tbQry.Top = 1;
            tbQry.Where.Add(new QueryParam(people.Collumns[People.FieldsName.Id], eCondition.ecGraterThan, 0));

            var list = people.FillCollection<People>(tbQry);
            if (list.Count == 0)
                throw new Exception("Nenhum registro encontrado");
            else
                return list.First();
        }

        private void toolStripButtonNext_Click(object sender, EventArgs e)
        {
            try
            {
                _people = GetNextRecord();

                _people.SetModifyState();
                SetTextButton(buttonOK, GetFormState(_people));
                _binds.FillControls(_people);
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private People GetNextRecord()
        {
            var people = DBTeste.CreateObject<People>();
            var tbQry = new TableQuery(people);
            tbQry.Top = 1;
            tbQry.Where.Add(new QueryParam(people.Collumns[People.FieldsName.Id], eCondition.ecGraterThan, _people.Id));

            var list = people.FillCollection<People>(tbQry);
            if (list.Count == 0)
                throw new Exception("Nenhum registro encontrado");
            else
                return list.First();
        }
    }
}
