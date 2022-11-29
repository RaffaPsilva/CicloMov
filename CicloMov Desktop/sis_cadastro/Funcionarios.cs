﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CicloMov
{
    public partial class frm_funcionarios : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        String strsql;
        public frm_funcionarios()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            if (txt_nome_funcionarios.Text == "" || txt_end_funcionarios.Text == "" || txt_cel_funcionarios.Text == "" || txt_cpf_funcionarios.Text == "")
            {
                MessageBox.Show("Preencha todos os campos para prosseguir!");
            }
            else
            {
                try
                {
                    conexao = new SqlConnection(@"Server=LAB136-16\SQLEXPRESS; Database=bd_cadastro_clayteam; User id=sa; Password=123456;");
                    strsql = "INSERT INTO funcionarios (nome_funcionario, end_funcionario, cel_funcionario, cpf_funcionario) VALUES (@nome_funcionario,@end_funcionario,@cel_funcionario,@cpf_funcionario)";
                    comando = new SqlCommand(strsql, conexao);
                    comando.Parameters.AddWithValue("@nome_funcionario",
                    txt_nome_funcionarios.Text);
                    comando.Parameters.AddWithValue("@end_funcionario",
                    txt_end_funcionarios.Text);
                    comando.Parameters.AddWithValue("@cel_funcionario",
                    txt_cel_funcionarios.Text);
                    comando.Parameters.AddWithValue("@cpf_funcionario",
                    txt_cpf_funcionarios.Text);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("CADASTRO REALIZADO COM SUCESSO!!");

                    txt_cod_funcionarios.Text = "";
                    txt_nome_funcionarios.Text = "";
                    txt_end_funcionarios.Text = "";
                    txt_cel_funcionarios.Text = "";
                    txt_cpf_funcionarios.Text = "";
                    txt_pesquisar_funcionarios.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexao.Close();
                    conexao = null;
                    comando = null;
                }
            }
        }

        private void btn_editar_funcionarios_Click(object sender, EventArgs e)
        {
            //INÍCIO DO BLOCO DE PROGRAMAÇÃO
            if (txt_cod_funcionarios.Text == "" || txt_nome_funcionarios.Text == "" || txt_end_funcionarios.Text == "" || txt_cel_funcionarios.Text == "" || txt_cpf_funcionarios.Text == "")
            {
                MessageBox.Show("Preencha todos os campos para prosseguir!");
            }
            else
            {
                try
                {
                    //A variável conexao define uma string para conexão com o BD.
                    conexao = new SqlConnection(@"Server=LAB136-16\SQLEXPRESS; Database=bd_cadastro_clayteam; User id=sa; Password=123456;");
                    strsql = "UPDATE funcionarios SET nome_funcionario = @nome_funcionario, end_funcionario = @end_funcionario, cel_funcionario = @cel_funcionario, cpf_funcionario = @cpf_funcionario WHERE cod_funcionario = @codigo_funcionario";
                    comando = new SqlCommand(strsql, conexao);
                    comando.Parameters.AddWithValue("@codigo_funcionario",
                    txt_cod_funcionarios.Text);
                    comando.Parameters.AddWithValue("@nome_funcionario",
                    txt_nome_funcionarios.Text);
                    comando.Parameters.AddWithValue("@end_funcionario",
                    txt_end_funcionarios.Text);
                    comando.Parameters.AddWithValue("@cel_funcionario",
                    txt_cel_funcionarios.Text);
                    comando.Parameters.AddWithValue("@cpf_funcionario",
                    txt_cpf_funcionarios.Text);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("CADASTRO ATUALIZADO COM SUCESSO!!");

                    txt_cod_funcionarios.Text = "";
                    txt_nome_funcionarios.Text = "";
                    txt_end_funcionarios.Text = "";
                    txt_cel_funcionarios.Text = "";
                    txt_cpf_funcionarios.Text = "";
                    txt_pesquisar_funcionarios.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexao.Close();
                    conexao = null;
                    comando = null;
                }
                //FIM DO BLOCO DE PROGRAMAÇÃO
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            //INÍCIO DO BLOCO DE PROGRAMAÇÃO
            if (txt_cod_funcionarios.Text == "")
            {
                MessageBox.Show("Preencha todos os campos para prosseguir!");
            }
            else
            {
                try
                {
                    //A variável conexao define uma string para conexão com o BD.
                    conexao = new SqlConnection(@"Server=LAB136-16\SQLEXPRESS; Database=bd_cadastro_clayteam; User id=sa; Password=123456;");

                    //Sua rotina de exclusão
                    //Confirmando exclusão para o usuário

                    //A variável conexao define uma string para conexão com o BD.
                    conexao = new SqlConnection(@"Server=LAB136-16\SQLEXPRESS;
                Database=bd_cadastro_clayteam; User id=sa; Password=123456;");

                    if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        strsql = "DELETE funcionarios WHERE cod_funcionario  = @codigo_funcionario";
                        comando = new SqlCommand(strsql, conexao);
                        comando.Parameters.AddWithValue("@codigo_funcionario",
                        txt_cod_funcionarios.Text);
                        conexao.Open();
                        comando.ExecuteNonQuery();
                        MessageBox.Show("REGISTRO APAGADO COM SUCESSO!!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Operação Cancelada!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexao.Close();
                    conexao = null;
                    comando = null;
                }
                //FIM DO BLOCO DE PROGRAMAÇÃO
                txt_cod_funcionarios.Text = "";
                txt_nome_funcionarios.Text = "";
                txt_end_funcionarios.Text = "";
                txt_cel_funcionarios.Text = "";
                txt_cpf_funcionarios.Text = "";
                txt_pesquisar_funcionarios.Text = "";
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            //Apaga todos os dados dos campos preenchidos.
            txt_cod_funcionarios.Text = "";
            txt_nome_funcionarios.Text = "";
            txt_end_funcionarios.Text = "";
            txt_cel_funcionarios.Text = "";
            txt_cpf_funcionarios.Text = "";
            txt_pesquisar_funcionarios.Text = "";
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            btn_editar_funcionarios.Enabled = true;
            btn_excluir_funcionarios.Enabled = true;
            btn_cadastrar_funcionarios.Enabled = true;
            //INÍCIO DO BLOCO DE PROGRAMAÇÃO
            if (txt_pesquisar_funcionarios.Text == "")
            {
                MessageBox.Show("Preencha todos os campos para prosseguir!");
            }
            else
            {
                try
                {
                    //A variável conexao define uma string para conexão com o BD.
                    conexao = new SqlConnection(@"Server=LAB136-16\SQLEXPRESS; Database=bd_cadastro_clayteam; User id=sa; Password=123456;");
                    strsql = "SELECT * FROM funcionarios WHERE cod_funcionario = @codigo_funcionario";
                    comando = new SqlCommand(strsql, conexao);
                    comando.Parameters.AddWithValue("@codigo_funcionario",
                    txt_pesquisar_funcionarios.Text);
                    conexao.Open();
                    dr = comando.ExecuteReader();
                    if (dr.Read())
                    {
                        txt_cod_funcionarios.Text =
                        Convert.ToString(dr["cod_funcionario"]);
                        txt_nome_funcionarios.Text = (string)dr["nome_funcionario"];
                        txt_end_funcionarios.Text = (string)dr["end_funcionario"];
                        txt_cel_funcionarios.Text = (string)dr["cel_funcionario"];
                        txt_cpf_funcionarios.Text = (string)dr["cpf_funcionario"];
                    }
                    else
                    {
                        MessageBox.Show("Nenhum registro encontrado!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexao.Close();
                    conexao = null;
                    comando = null;
                }
                //FIM DO BLOCO DE PROGRAMAÇÃO
            }
        }

        private void frm_funcionarios_Load(object sender, EventArgs e)
        {
            txt_cod_funcionarios.Enabled = false;
        }

        private void btn_voltar_menu_Click(object sender, EventArgs e)
        {
            this.Hide();

            frm_menu voltar_menu = new frm_menu();

            voltar_menu.Show();
        }

    }
}
