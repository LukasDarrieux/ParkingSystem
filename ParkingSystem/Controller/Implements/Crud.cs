using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Controller.Interfaces;
using ParkingSystem.Utils.Implements;
using ParkingSystem.Utils.Interfaces;

namespace ParkingSystem.Controller.Implements
{
    class Crud : ICrud, IDisposable
    {
        private IDatabase db;
        private string Tabela;
        private string[] Campos;
        private string[] Valores;

        public Crud(IDatabase db, string tabela, string[] campos, string[] valores)
        {
            this.db = db;
            Tabela = tabela;
            Campos = campos;
            Valores = valores;
        }

        public bool Delete()
        {
            try
            {
                if ((Campos.Length > 0 && Valores.Length > 0) && (Campos.Length == Valores.Length) && HasFieldID())
                {
                    string sql = $"DELETE FROM {Tabela} WHERE ";
                    string conditions = "";
                    for (int cont = 0; cont < Campos.Length; cont++)
                    {
                        if (conditions.Trim().Length > 0) conditions += ", ";
                        conditions += $"{Campos[cont]}='{Valores[cont]}'";
                    }

                    sql += conditions;

                    db.ExecuteSql(sql);

                    return true;
                }
                return false;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool Insert()
        {
            try
            {
                if ((Campos.Length > 0 && Valores.Length > 0) && (Campos.Length == Valores.Length))
                {
                    string fields = "(";
                    string values = "(";
                    
                    for (int cont = 1; cont < Campos.Length; cont++)
                    {
                        if (cont > 1)
                        {
                            fields += ", ";
                            values += ", ";
                        }
                        fields += $"{Campos[cont]}";
                        values += $"'{Valores[cont]}'";
                    }
                    fields += ")";
                    values += ")";

                    string sql = $"INSERT INTO {Tabela}{fields} VALUES{values}";

                    db.ExecuteSql(sql);

                    return true;
                }
                return false;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool Update()
        {
            try
            {
                if ((Campos.Length > 0 && Valores.Length > 0) && (Campos.Length == Valores.Length) && HasFieldID())
                {
                    string whereId = "";
                    string fields = "";

                    string sql = $"UPDATE {Tabela} SET ";

                    for (int cont = 0; cont < Campos.Length; cont++)
                    {
                        if (Campos[cont].ToUpper() == "ID")
                        {
                            whereId = $" WHERE {Campos[cont]} = { Valores[cont]}";
                        }
                        else
                        {
                            if (fields.Trim().Length > 0) fields += ", ";
                            fields += $"{Campos[cont]}='{Valores[cont]}'";
                        }
                        
                    }
                    sql += fields + whereId;

                    db.ExecuteSql(sql);

                    return true;
                }
                return false;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Dispose()
        {
            Tabela = null;
            Campos = null;
            Valores = null;
        }

        private bool HasFieldID()
        {
            return (Campos.Contains<string>("ID") || 
                Campos.Contains<string>("id") || 
                Campos.Contains<string>("Id") || 
                Campos.Contains<string>("iD"));
        }
    }
}
