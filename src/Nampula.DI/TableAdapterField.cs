using System;
using System.Data;
using System.ComponentModel;


namespace Nampula.DI
{
    /// <summary>
    /// Um campo na tabela
    /// </summary>
    [Serializable]
    public class TableAdapterField : INotifyPropertyChanged, INotifyPropertyChanging
    {

        /// <summary>
        /// Cria um novo campo
        /// </summary>
        public TableAdapterField()
        {
            Name = String.Empty;
            Description = String.Empty;
            DbType = DbType.String;
            Value = null;
            DefaultValue = null;
            Size = 11;
            Key = false;
            Identity = false;
            Precision = 19;
            Scale = 6;
            FieldType = eFieldType.eResult;
        }

        /// <summary>
        /// Cosntrutor padrão
        /// </summary>
        /// <param name="pTableAdapterField"></param>
        public TableAdapterField(TableAdapterField pTableAdapterField)
            : this()
        {
            Alias = pTableAdapterField.Alias;
            TableAlias = pTableAdapterField.TableAlias;
            Name = pTableAdapterField.Name;
            Description = pTableAdapterField.Description;
            DbType = pTableAdapterField.DbType;
            Value = pTableAdapterField.Value;
            DefaultValue = pTableAdapterField.DefaultValue;
            Size = pTableAdapterField.Size;
            Key = pTableAdapterField.Key;
            Identity = pTableAdapterField.Identity;
            Precision = pTableAdapterField.Precision;
            Scale = pTableAdapterField.Scale;
            FieldType = pTableAdapterField.FieldType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pDescription"></param>
        /// <param name="size"></param>
        public TableAdapterField(string pName, string pDescription, int size)
            : this()
        {
            Name = pName;
            Description = pDescription;
            Size = size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pDescription"></param>
        /// <param name="pSize"></param>
        /// <param name="pValue"></param>
        public TableAdapterField(string pName, string pDescription, int pSize, object pValue)
            : this(pName, pDescription, pSize)
        {
            Value = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pDescription"></param>
        /// <param name="pDbType"></param>
        public TableAdapterField(string pName, string pDescription, DbType pDbType)
            : this(pName, pDescription, 0)
        {

            DbType = pDbType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pDescription"></param>
        /// <param name="pDbType"></param>
        /// <param name="pSize"></param>
        /// <param name="pValue"></param>
        /// <param name="pKey"></param>
        /// <param name="pIdentity"></param>
        public TableAdapterField(string pName, string pDescription, DbType pDbType, int pSize, object pValue, bool pKey, bool pIdentity)
            : this(pName, pDescription, pDbType)
        {
            Size = pSize;
            Value = pValue;
            Key = pKey;
            Identity = pIdentity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pDescription"></param>
        /// <param name="pDbType"></param>
        /// <param name="pPrecision"></param>
        /// <param name="pScale"></param>
        public TableAdapterField(string pName, string pDescription, DbType pDbType, int pPrecision, int pScale)
            : this(pName, pDescription, pDbType)
        {
            Precision = pPrecision;
            Scale = pScale;
        }

        /// <summary>
        /// TableAdapter coluna
        /// </summary>
        public TableAdapter TableAdapter { get; internal set; }

        /// <summary>
        /// Alias da Tabela exempo [Nome da Tabel] T0
        /// </summary>
        public string TableAlias { get; set; }
        /// <summary>
        /// Alias do Campos
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// Nome do Campos
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Tipo do Campos
        /// </summary>
        public DbType DbType { get; set; }
        /// <summary>
        /// Valor padrão
        /// </summary>
        public object DefaultValue { get; set; }
        /// <summary>
        /// Tamanho do Campo
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// Eh uma chave
        /// </summary>
        public bool Key { get; set; }
        /// <summary>
        /// Auto Incremental
        /// </summary>
        public bool Identity { get; set; }
        //public int Version { get; set; }
        /// <summary>
        /// Precisao do Numero
        /// </summary>
        public int Precision { get; set; }
        /// <summary>
        /// Escala decimal
        /// </summary>
        public int Scale { get; set; }
        /// <summary>
        /// Tipo de Consulta
        /// </summary>
        public eFieldType FieldType { get; set; }

        /// <summary>
        /// Pega o valor como string
        /// </summary>
        /// <returns>Um String</returns>
        public string GetString()
        {
            return Value == null ? string.Empty : Value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int16 GetInt16()
        {
            return Value == null ? default(Int16) : Convert.ToInt16(Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int32 GetInt32()
        {
            return Value == null ? default(Int32) : Convert.ToInt32(Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int64 GetInt64()
        {
            return Value == null ? default(Int64) : Convert.ToInt64(Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UInt16 GetUInt16()
        {
            return Value == null ? default(UInt16) : Convert.ToUInt16(Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UInt32 GetUInt32()
        {
            return Value == null ? default(UInt32) : Convert.ToUInt32(Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UInt64 GetUInt64()
        {
            return Value == null ? default(UInt64) : Convert.ToUInt64(Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetDecimal()
        {
            return Value == null ? default(decimal) : Convert.ToDecimal(Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetBool()
        {
            return Value != null && Convert.ToBoolean(Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetBoolean()
        {
            return GetBool();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTime()
        {
            return Value == null ? DateTime.MinValue : Convert.ToDateTime(Value);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetDouble()
        {
            return Value == null ? Double.NaN : Convert.ToDouble(Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetFloat()
        {
            return Value == null ? float.NaN : float.Parse(Value.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public char GetChar()
        {
            return Value == null ? string.Empty[0] : Convert.ToChar(Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool DbTypeIsNumeric()
        {
            switch (DbType)
            {
                case DbType.Currency:
                case DbType.Int16:
                case DbType.Int32:
                case DbType.Int64:
                case DbType.Single:
                case DbType.Decimal:
                case DbType.UInt16:
                case DbType.UInt32:
                case DbType.UInt64:
                case DbType.VarNumeric:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Type GetDbType()
        {
            var toReturn = typeof(DBNull);

            switch (DbType)
            {
                case DbType.String:
                    toReturn = typeof(string);
                    break;
                case DbType.UInt64:
                    toReturn = typeof(UInt64);
                    break;

                case DbType.Int64:
                    toReturn = typeof(Int64);
                    break;

                case DbType.Int32:
                    toReturn = typeof(Int32);
                    break;

                case DbType.UInt32:
                    toReturn = typeof(UInt32);
                    break;

                case DbType.Single:
                    toReturn = typeof(float);
                    break;

                case DbType.Date:
                    toReturn = typeof(DateTime);
                    break;

                case DbType.DateTime:
                    toReturn = typeof(DateTime);
                    break;

                case DbType.Time:
                    toReturn = typeof(DateTime);
                    break;

                case DbType.StringFixedLength:
                    toReturn = typeof(string);
                    break;

                case DbType.UInt16:
                    toReturn = typeof(UInt16);
                    break;

                case DbType.Int16:
                    toReturn = typeof(Int16);
                    break;

                case DbType.SByte:
                    toReturn = typeof(byte);
                    break;

                case DbType.Object:
                    toReturn = typeof(object);
                    break;

                case DbType.AnsiString:
                    toReturn = typeof(string);
                    break;

                case DbType.AnsiStringFixedLength:
                    toReturn = typeof(string);
                    break;

                case DbType.VarNumeric:
                    toReturn = typeof(decimal);
                    break;

                case DbType.Currency:
                    toReturn = typeof(double);
                    break;

                case DbType.Binary:
                    toReturn = typeof(byte[]);
                    break;

                case DbType.Decimal:
                    toReturn = typeof(decimal);
                    break;

                case DbType.Double:
                    toReturn = typeof(Double);
                    break;

                case DbType.Guid:
                    toReturn = typeof(Guid);
                    break;

                case DbType.Boolean:
                    toReturn = typeof(bool);
                    break;
            }

            return toReturn;
        }

        /// <summary>
        /// Converte o valor da classe para string, usado para facilitar debug
        /// </summary>
        /// <returns>Um String [Nome do Campo] [Valor do Campo]</returns>
        public override string ToString()
        {
            return string.Format("[{0}] [{1}]", Name, Value);
        }

        private object _valueField;

        /// <summary>
        /// Valor do campos
        /// </summary>
        public object Value
        {
            get { return _valueField; }
            set { SetValue(value); }
        }

        /// <summary>
        /// Novo valor a ser atribuido no campo Value
        /// </summary>
        public object ValueNew { get; set; }

        /// <summary>
        /// Valor antigo relacionado ao Value
        /// </summary>
        public object ValueOld { get; set; }

        /// <summary>
        /// Bloquei notificações de alteração
        /// </summary>
        public Boolean LockNotify { get; set; }

        /// <summary>
        /// Evento disparado quando alguma atualização é realizada
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Evento disparado quando alguma atualização está sendo realizada
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Atribui um novo valor a coluna
        /// </summary>
        /// <typeparam name="TT">Tipo do Objeto</typeparam>
        /// <param name="newValue">Novo Valor do Camp</param>
        private void SetValue<TT>(TT newValue)
        {
            if (LockNotify)
            {
                SetValueOfField(newValue);
                return;
            }

            if (!Equals(_valueField, newValue))
            {
                try
                {
                    LockNotify = true;

                    ValueNew = newValue;

                    if (PropertyChanging != null)
                        PropertyChanging(this, new PropertyChangingEventArgs(Name));

                    SetValueOfField(newValue);

                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs(Name));
                }
                finally
                {
                    LockNotify = false;
                }
            }
        }

        private void SetValueOfField<TT>(TT newValue)
        {
            ValueOld = _valueField;
            _valueField = newValue;
        }
    }
}

