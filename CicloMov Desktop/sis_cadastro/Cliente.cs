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
    public partial class frm_cliente : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        String strsql;
        public frm_cliente()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            if (txt_nome_cliente.Text == "" || txt_end_cliente.Text == "" || txt_cel_cliente.Text == "" || txt_cpf_cliente.Text == "")
            {
                MessageBox.Show("Preencha todos os campos para prosseguir!");
            }
            else
            {
                try
                {
                    conexao = new SqlConnection(@"Server=LAB136-16\SQLEXPRESS; Database=bd_cadastro_clayteam; User id=sa; Password=123456;");
                    strsql = "INSERT INTO CLIENTES (nome_cliente, end_cliente, cel_cliente, cpf_cliente) VALUES (@nome_cliente,@end_cliente,@cel_cliente,@cpf_cliente)";
                    comando = new SqlCommand(strsql, conexao);
                    comando.Parameters.AddWithValue("@nome_cliente",
                    txt_nome_cliente.Text);
                    comando.Parameters.AddWithValue("@end_cliente",
                    txt_end_cliente.Text);
                    comando.Parameters.AddWithValue("@cel_cliente",
                    txt_cel_cliente.Text);
                    comando.Parameters.AddWithValue("@cpf_cliente",
                    txt_cpf_cliente.Text);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("CADASTRO REALIZADO COM SUCESSO!!");

                    txt_cod_cliente.Text = "";
                    txt_nome_cliente.Text = "";
                    txt_end_cliente.Text = "";
                    txt_cel_cliente.Text = "";
                    txt_cpf_cliente.Text = "";
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

        private void btn_editar_Click(object sender, EventArgs e)
        {
            txt_cod_cliente.Enabled = false;
            //INÍCIO DO BLOCO DE PROGRAMAÇÃO
            if (txt_cod_cliente.Text == "" || txt_nome_cliente.Text == "" || txt_end_cliente.Text == "" || txt_cel_cliente.Text == "" || txt_cpf_cliente.Text == "")
            {
                MessageBox.Show("Preencha todos os campos para prosseguir!");
            }
            else
            {
                try
                {
                    //A variável conexao define uma string para conexão com o BD.
                    conexao = new SqlConnection(@"Server=LAB136-16\SQLEXPRESS; Database=bd_cadastro_clayteam; User id=sa; Password=123456;");
                    strsql = "UPDATE clientes SET nome_cliente = @nome_cliente, end_cliente = @end_cliente, cel_cliente = @cel_cliente, cpf_cliente = @cpf_cliente WHERE codigo_cliente = @codigo_cliente";
                    comando = new SqlCommand(strsql, conexao);
                    comando.Parameters.AddWithValue("@codigo_cliente",
                    txt_cod_cliente.Text);
                    comando.Parameters.AddWithValue("@nome_cliente",
                    txt_nome_cliente.Text);
                    comando.Parameters.AddWithValue("@end_cliente",
                    txt_end_cliente.Text);
                    comando.Parameters.AddWithValue("@cel_cliente",
                    txt_cel_cliente.Text);
                    comando.Parameters.AddWithValue("@cpf_cliente",
                    txt_cpf_cliente.Text);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("CADASTRO ATUALIZADO COM SUCESSO!!");

                    txt_cod_cliente.Text = "";
                    txt_nome_cliente.Text = "";
                    txt_end_cliente.Text = "";
                    txt_cel_cliente.Text = "";
                    txt_cpf_cliente.Text = "";
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
            //FIM DO BLOCO DE PROGRAMAÇÃO
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            //INÍCIO DO BLOCO DE PROGRAMAÇÃO
            if (txt_cod_cliente.Text == "")
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
                        strsql = "DELETE clientes WHERE codigo_cliente = @codigo_cliente";
                        comando = new SqlCommand(strsql, conexao);
                        comando.Parameters.AddWithValue("@codigo_cliente",
                        txt_cod_cliente.Text);
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
                txt_cod_cliente.Text = "";
                txt_nome_cliente.Text = "";
                txt_end_cliente.Text = "";
                txt_cel_cliente.Text = "";
                txt_cpf_cliente.Text = "";
                txt_pesquisar.Text = "";
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            //Apaga todos os dados dos campos preenchidos.
            txt_cod_cliente.Text = "";
            txt_nome_cliente.Text = "";
            txt_end_cliente.Text = "";
            txt_cel_cliente.Text = "";
            txt_cpf_cliente.Text = "";
            txt_pesquisar.Text = "";
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            btn_editar.Enabled = true;
            btn_excluir.Enabled = true;
            btn_cadastrar.Enabled = true;
            //INÍCIO DO BLOCO DE PROGRAMAÇÃO
            if (txt_pesquisar.Text == "")
            {
                MessageBox.Show("Preencha todos os campos para prosseguir!");
            }
            else
            {
                try
                {
                    //A variável conexao define uma string para conexão com o BD.
                    conexao = new SqlConnection(@"Server=LAB136-16\SQLEXPRESS; Database=bd_cadastro_clayteam; User id=sa; Password=123456;");
                    strsql = "SELECT * FROM CLIENTES WHERE codigo_cliente = @codigo_cliente";
                    comando = new SqlCommand(strsql, conexao);
                    comando.Parameters.AddWithValue("@codigo_cliente",
                    txt_pesquisar.Text);
                    conexao.Open();
                    dr = comando.ExecuteReader();
                    if (dr.Read())
                    {
                        txt_cod_cliente.Text =
                        Convert.ToString(dr["codigo_cliente"]);
                        txt_nome_cliente.Text = (string)dr["nome_cliente"];
                        txt_end_cliente.Text = (string)dr["end_cliente"];
                        txt_cel_cliente.Text = (string)dr["cel_cliente"];
                        txt_cpf_cliente.Text = (string)dr["cpf_cliente"];
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

        private void btn_voltar_menu_Click(object sender, EventArgs e)
        {
            this.Hide();

            frm_menu voltar_menu = new frm_menu();

            voltar_menu.Show();
        }

        private void frm_clientes_Load(object sender, EventArgs e)
        {
            txt_cod_cliente.Enabled = false;
        }
    }
}
