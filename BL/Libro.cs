using Braintree;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result GetAll(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "LibroGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableLibro = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableLibro);

                        if (tableLibro.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableLibro.Rows)
                            {
                                libro = new ML.Libro();
                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.Titulo = row[1].ToString();
                                libro.AñoPublicacion = row[2].ToString();
                                libro.Editorial = new ML.Editorial();
                                libro.Editorial.IdEditorial = int.Parse(row[3].ToString());
                                libro.Editorial.Nombre = row[4].ToString();
                                libro.Autor = new ML.Autor();
                                libro.Autor.IdAutor = int.Parse(row[5].ToString());
                                libro.Autor.NombreCompleto = row[6].ToString();
                                libro.Genero = new ML.Genero();
                                libro.Genero.IdGenero = int.Parse(row[7].ToString());
                                libro.Genero.Nombre = row[8].ToString();
                                libro.NumeroPaginas = row[9].ToString();
                                libro.Descripcion = row[10].ToString();
                                if (row[11].ToString() == "")
                                {
                                    libro.Imagen = new byte[0];
                                }
                                else
                                {

                                    libro.Imagen = (byte[])row[11];
                                }

                                result.Objects.Add(libro);

                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "LibroAdd"; //Nombre SP
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("Titulo", SqlDbType.VarChar);
                        collection[0].Value = libro.Titulo;

                        collection[1] = new SqlParameter("AñoPublicacion", SqlDbType.VarChar);
                        collection[1].Value = libro.AñoPublicacion;

                        collection[2] = new SqlParameter("IdEditorial", SqlDbType.Int);
                        collection[2].Value = libro.Editorial.IdEditorial;

                        collection[3] = new SqlParameter("IdAutor", SqlDbType.Int);
                        collection[3].Value = libro.Autor.IdAutor;

                        collection[4] = new SqlParameter("IdGenero", SqlDbType.Int);
                        collection[4].Value = libro.Genero.IdGenero;

                        collection[5] = new SqlParameter("NumeroPaginas", SqlDbType.VarChar);
                        collection[5].Value = libro.NumeroPaginas;

                        collection[6] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[6].Value = libro.Descripcion;

                        collection[7] = new SqlParameter("Imagen", SqlDbType.VarBinary);
                        collection[7].Value = libro.Imagen;


                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }

                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }
        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "LibroGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = IdLibro;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tablaLibro = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablaLibro);

                        if (tablaLibro.Rows.Count > 0)
                        {
                            DataRow row = tablaLibro.Rows[0];

                            ML.Libro libro = new ML.Libro();

                            libro = new ML.Libro();

                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.Titulo = row[1].ToString();
                            libro.AñoPublicacion = row[2].ToString();
                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = int.Parse(row[3].ToString());
                            libro.Editorial.Nombre = row[4].ToString();
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = int.Parse(row[5].ToString());
                            libro.Autor.NombreCompleto = row[6].ToString();
                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = int.Parse(row[7].ToString());
                            libro.Genero.Nombre = row[8].ToString();
                            libro.NumeroPaginas = row[9].ToString();
                            libro.Descripcion = row[10].ToString();
                            if (row[11].ToString() == "")
                            {
                                libro.Imagen = new byte[0];
                            }
                            else
                            {

                                libro.Imagen = (byte[])row[11];
                            }

                            result.Object = libro;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result LibroGetByTituloyAutor(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "LibroGetByTituloyAutor";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("Titulo", SqlDbType.VarChar);
                        collection[0].Value = libro.Titulo;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = libro.Autor.Nombre;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tablaLibro = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablaLibro);

                        if (tablaLibro.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tablaLibro.Rows)
                            {

                                libro = new ML.Libro();

                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.Titulo = row[1].ToString();
                                libro.AñoPublicacion = row[2].ToString();
                                libro.Editorial = new ML.Editorial();
                                libro.Editorial.IdEditorial = int.Parse(row[3].ToString());
                                libro.Editorial.Nombre = row[4].ToString();
                                libro.Autor = new ML.Autor();
                                libro.Autor.IdAutor = int.Parse(row[5].ToString());
                                libro.Autor.Nombre = row[6].ToString();
                                libro.Genero = new ML.Genero();
                                libro.Genero.IdGenero = int.Parse(row[7].ToString());
                                libro.Genero.Nombre = row[8].ToString();
                                libro.NumeroPaginas = row[9].ToString();
                                libro.Descripcion = row[10].ToString();
                                if (row[11].ToString() == "")
                                {
                                    libro.Imagen = new byte[0];
                                }
                                else
                                {

                                    libro.Imagen = (byte[])row[11];
                                }

                                result.Objects.Add(libro);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result LibroGetByAutor(int IdAutor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "LibroGetByAutor";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAutor", SqlDbType.Int);
                        collection[0].Value = IdAutor;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tablaLibro = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablaLibro);

                        if (tablaLibro.Rows.Count > 0)
                        {
                            DataRow row = tablaLibro.Rows[0];

                            ML.Libro libro = new ML.Libro();

                            libro = new ML.Libro();

                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.Titulo = row[1].ToString();
                            libro.AñoPublicacion = row[2].ToString();
                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = int.Parse(row[3].ToString());
                            libro.Editorial.Nombre = row[4].ToString();
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = int.Parse(row[5].ToString());
                            libro.Autor.Nombre = row[6].ToString();
                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = int.Parse(row[7].ToString());
                            libro.Genero.Nombre = row[8].ToString();
                            libro.NumeroPaginas = row[9].ToString();
                            libro.Descripcion = row[10].ToString();
                            if (row[11].ToString() == "")
                            {
                                libro.Imagen = new byte[0];
                            }
                            else
                            {

                                libro.Imagen = (byte[])row[11];
                            }

                            result.Object = libro;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        //LibroGetByTitulo
        public static ML.Result LibroGetByTitulo(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "LibroGetByTitulo";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("Titulo", SqlDbType.VarChar);
                        collection[0].Value = libro;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tablaLibro = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablaLibro);

                        if (tablaLibro.Rows.Count > 0)
                        {
                            DataRow row = tablaLibro.Rows[0];

                            libro = new ML.Libro();

                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.Titulo = row[1].ToString();
                            libro.AñoPublicacion = row[2].ToString();
                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = int.Parse(row[3].ToString());
                            libro.Editorial.Nombre = row[4].ToString();
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = int.Parse(row[5].ToString());
                            libro.Autor.Nombre = row[6].ToString();
                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = int.Parse(row[7].ToString());
                            libro.Genero.Nombre = row[8].ToString();
                            libro.NumeroPaginas = row[9].ToString();
                            libro.Descripcion = row[10].ToString();
                            if (row[11].ToString() == "")
                            {
                                libro.Imagen = new byte[0];
                            }
                            else
                            {

                                libro.Imagen = (byte[])row[11];
                            }

                            result.Object = libro;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        //LibroGetByAutorYFecha

        public static ML.Result LibroGetByAutorYFecha(int IdAutor, ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "LibroGetByAutorYFecha";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("IdAutor", SqlDbType.Int);
                        collection[0].Value = IdAutor;

                        collection[1] = new SqlParameter("AñoPublicacion", SqlDbType.Int);
                        collection[1].Value = libro;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tablaLibro = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablaLibro);

                        if (tablaLibro.Rows.Count > 0)
                        {
                            DataRow row = tablaLibro.Rows[0];

                            libro = new ML.Libro();

                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.Titulo = row[1].ToString();
                            libro.AñoPublicacion = row[2].ToString();
                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = int.Parse(row[3].ToString());
                            libro.Editorial.Nombre = row[4].ToString();
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = int.Parse(row[5].ToString());
                            libro.Autor.Nombre = row[6].ToString();
                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = int.Parse(row[7].ToString());
                            libro.Genero.Nombre = row[8].ToString();
                            libro.NumeroPaginas = row[9].ToString();
                            libro.Descripcion = row[10].ToString();
                            if (row[11].ToString() == "")
                            {
                                libro.Imagen = new byte[0];
                            }
                            else
                            {

                                libro.Imagen = (byte[])row[11];
                            }

                            result.Object = libro;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(int? IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    //context.Open();
                    string query = "LibroDelete";

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdLibro", +IdLibro);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result LibroGetByEditorial(ML.Editorial editorial)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "LibroGetByEditorial";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = editorial.Nombre;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tablaLibro = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablaLibro);

                        if (tablaLibro.Rows.Count > 0)
                        {
                            DataRow row = tablaLibro.Rows[0];

                            ML.Libro libro = new ML.Libro();

                            libro = new ML.Libro();

                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.Titulo = row[1].ToString();
                            libro.AñoPublicacion = row[2].ToString();
                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = int.Parse(row[3].ToString());
                            libro.Editorial.Nombre = row[4].ToString();
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = int.Parse(row[5].ToString());
                            libro.Autor.Nombre = row[6].ToString();
                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = int.Parse(row[7].ToString());
                            libro.Genero.Nombre = row[8].ToString();
                            libro.NumeroPaginas = row[9].ToString();
                            libro.Descripcion = row[10].ToString();
                            if (row[11].ToString() == "")
                            {
                                libro.Imagen = new byte[0];
                            }
                            else
                            {

                                libro.Imagen = (byte[])row[11];
                            }

                            result.Object = libro;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "LibroUpdate";

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = context;

                    SqlParameter[] collection = new SqlParameter[6];

                    collection[0] = new SqlParameter("@IdLibro", SqlDbType.Int);
                    collection[0].Value = libro.IdLibro;

                    collection[1] = new SqlParameter("@Titulo", SqlDbType.VarChar);
                    collection[1].Value = libro.Titulo;

                    collection[2] = new SqlParameter("@AñoPublicacion", SqlDbType.VarChar);
                    collection[2].Value = libro.AñoPublicacion;

                    collection[3] = new SqlParameter("@IdEditorial", SqlDbType.Int);
                    collection[3].Value = libro.Editorial.IdEditorial;

                    collection[4] = new SqlParameter("@IdAutor", SqlDbType.Int);
                    collection[4].Value = libro.Autor.IdAutor;

                    collection[5] = new SqlParameter("@IdGenero", SqlDbType.Int);
                    collection[5].Value = libro.Genero.IdGenero;

                    collection[6] = new SqlParameter("@IdGenero", SqlDbType.Int);
                    collection[6].Value = libro.Genero.IdGenero;

                    cmd.Parameters.AddRange(collection);

                    //Siempre abrir la conexión
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}