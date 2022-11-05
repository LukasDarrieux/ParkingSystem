using ParkingSystem.Controller.Interfaces;
using ParkingSystem.Models.Usuario;
using ParkingSystem.Shared;
using ParkingSystem.Utils.Implements;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace ParkingSystem.Controller.Implements
{
    class UsuariosController : IUsuariosController, ICrud, IDisposable
    {
        #region "Atributos"

        private Usuarios _usuario;
        private Database db;
        private const string TABELA = "USUARIOS";

        #endregion

        #region "Construtores"

        public UsuariosController(Usuarios usuario)
        {
            this._usuario = usuario;
            this.db = Configuracoes.GetDatabase();
        }

        public UsuariosController()
        {
            this.db = Configuracoes.GetDatabase();
        }

        #endregion

        #region "Métodos públicos"

        public bool Delete()
        {
            return this.Delete(_usuario);
        }

        public bool Delete(Usuarios usuario)
        {
            if (usuario is null) return false;
            Crud crud = new Crud(this.db, TABELA, GetFieldID(), GetValueID(usuario.Id));
            try
            {
                if (usuario.Id <= uint.MinValue) return false;

                if (!crud.Delete()) return false;

                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                crud.Dispose();
            }
        }

        public Usuarios Get(int id)
        {
            string sql = $"SELECT * FROM {TABELA} WHERE {Usuarios.Campos.ID.ToString()}={id.ToString()}";
            List<Usuarios> listaUsuarios = GetUsuarios(sql);

            if (listaUsuarios is null) return null;

            if (listaUsuarios.Count == 1)
            {
                return listaUsuarios.ElementAt<Usuarios>(0);
            }
            return null;
        }

        public List<Usuarios> GetAll()
        {
            string sql = $"SELECT * FROM {TABELA}";
            return GetUsuarios(sql);
        }

        public List<Usuarios> GetAll(Usuarios usuario)
        {
            string sql = $"SELECT * FROM {TABELA}";
            if (!(usuario is null))
            {
                string conditions = string.Empty;

                if (usuario.Id > 0) conditions = $" WHERE ID={usuario.Id.ToString()}";

                if (!String.IsNullOrEmpty(usuario.Nome))
                {
                    if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                    else conditions += $" AND ";
                    conditions += $"{Usuarios.Campos.NOME} LIKE '{usuario.Nome}%'";
                }

                if (!String.IsNullOrEmpty(usuario.Email))
                {
                    if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                    else conditions += $" AND ";
                    conditions += $"{Usuarios.Campos.EMAIL} LIKE '{usuario.Email}%'";
                }
                sql += conditions;
            }
            return GetUsuarios(sql);
        }

        public bool Insert()
        {
            return this.Insert(_usuario);
        }

        public bool Insert(Usuarios usuario)
        {
            if (usuario is null) return false;
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues(usuario));
            try
            {
                if (UsuarioExists(usuario))
                {
                    General.MessageShowAttention("E-mail já cadastrado!");
                    return false;
                }

                if (!crud.Insert())
                {
                    General.MessageShowAttention("Não foi possível salvar usuário!");
                    return false;
                }
                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                crud.Dispose();
            }
        }

        public bool Update()
        {
            return this.Update(_usuario);
        }

        public bool Update(Usuarios usuario)
        {
            if (usuario is null) return false;
            Crud crud = new Crud(db, TABELA, GetFields(true), GetValues(usuario, true));
            try
            {
                if (usuario is null) return false;

                if (usuario.IsAdmin())
                {
                    General.MessageShowAttention("Não é possível alterar os dados do usuário administrador");
                    return false;
                }

                if (!crud.Update())
                {
                    General.MessageShowAttention("Não foi possível atualizar usuário!");
                    return false;
                }
                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                crud.Dispose();
            }
        }

        public Usuarios Login(string email, string password)
        {
            const int SENHA = 3;

            DbDataReader dbReader = db.ExecuteQuery($"SELECT ID, NOME, EMAIL, SENHA FROM USUARIOS WHERE EMAIL='{email}'");
            try
            {
                if (dbReader.HasRows)
                {
                    if (dbReader.Read())
                    {
                        if (dbReader.GetString(SENHA) == password)
                        {
                            int id = dbReader.GetFieldValue<int>((int)Usuarios.Campos.ID);
                            string nome = dbReader.GetString((int)Usuarios.Campos.NOME);
                            
                            _usuario = new Usuarios(id, nome, email, string.Empty);
                        }
                    }
                }
                return _usuario;
            }
            catch(Exception error)
            {
                throw error;
            }
            finally
            {
                dbReader.Close();
                dbReader.Dispose();
            }
        }

        public bool UpdatePassword(Usuarios usuario, string oldPassword, string newPassword)
        {
            const int ID = 0;
            const int SENHA = 3;

            DbDataReader dbReader = db.ExecuteQuery($"SELECT ID, NOME, EMAIL, SENHA FROM USUARIOS WHERE NOME={usuario.Nome} AND EMAIL={usuario.Email}");
            try
            {
                if (dbReader.HasRows)
                {
                    if (dbReader.Read())
                    {
                        if (oldPassword == dbReader.GetString(SENHA))
                        {
                            db.ExecuteSql($"UPDATE USUARIOS SET SENHA={newPassword} WHERE ID={dbReader.GetString(ID)} AND EMAIL={usuario.Email}");
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                dbReader.Close();
                dbReader.Dispose();
            }
        }

        public void Dispose()
        {
            this.db.Dispose();
            if (!(_usuario is null))
            {
                _usuario.Dispose();
            }
        }

        #endregion

        #region "Métodos privados"

        private string[] GetFields()
        {
            string[] campos =
            {
                Usuarios.Campos.ID.ToString(),
                Usuarios.Campos.NOME.ToString(),
                Usuarios.Campos.EMAIL.ToString(),
                Usuarios.Campos.SENHA.ToString()
            };

            return campos;
        }

        private string[] GetFields(bool IsUpdate)
        {
            string[] campos =
            {
                Usuarios.Campos.ID.ToString(),
                Usuarios.Campos.NOME.ToString(),
                Usuarios.Campos.EMAIL.ToString(),
            };

            return campos;
        }

        private string[] GetValues(Usuarios usuario)
        {
            if (usuario is null) return null;

            string[] valores =
            {
                usuario.Id.ToString(),
                usuario.Nome,
                usuario.Email,
                usuario.Senha
            };

            return valores;
        }

        private string[] GetValues(Usuarios usuario, bool IsUpdate)
        {
            if (usuario is null) return null;

            string[] valores =
            {
                usuario.Id.ToString(),
                usuario.Nome,
                usuario.Email
            };

            return valores;
        }

        private string[] GetFieldID()
        {
            return new string[] { Usuarios.Campos.ID.ToString() };
        }

        private string[] GetValueID(int id)
        {
            return new string[] { id.ToString() };
        }

        private List<Usuarios> GetUsuarios(string sql)
        {
            DbDataReader reader = db.ExecuteQuery(sql);

            try
            {
                List<Usuarios> listaUsuarios = null;
                if (reader.HasRows)
                {
                    listaUsuarios = new List<Usuarios>();

                    while (reader.Read())
                    {
                        int id = reader.GetFieldValue<int>((int)Usuarios.Campos.ID);
                        string nome = reader.GetString((int)Usuarios.Campos.NOME);
                        string email = reader.GetString((int)Usuarios.Campos.EMAIL);

                        listaUsuarios.Add(new Usuarios(id, nome, email, string.Empty));

                    }
                }
                return listaUsuarios;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }
        }

        private bool UsuarioExists(Usuarios usuario)
        {
            List<Usuarios> listaUsuarios = null;
            try
            {
                listaUsuarios = this.GetAll(usuario);

                if (listaUsuarios is null) return false;

                return listaUsuarios.Contains(usuario);
            }
            finally
            {
                if (!(listaUsuarios is null))
                {
                    listaUsuarios.Clear();
                    listaUsuarios = null;
                }
                
            }
            
        }

        #endregion
    }
}
